﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using StatsSystem.Enum;
using UnityEngine;

namespace StatsSystem
{
    public class StatsController : IDisposable, IStatValueGiver
    {
        private readonly List<Stat> _currentStats;
        private readonly List<StatModificator> _activeModificators;

        public StatsController(List<Stat> currentStats)
        {
            _currentStats = currentStats;
            _activeModificators = new List<StatModificator>();
            ProjectUpdater.Instanse.UpdateCalled += OnUpdate;
        }

        public float GetStatValue(StatType statType) => _currentStats.Find(stat => stat.Type == statType);

        public void ProcessModificator(StatModificator modificator)
        {
            var statToChange = _currentStats.Find(stat => stat.Type == modificator.Stat.Type);
            if (statToChange == null) 
                return;

            var addedValue = modificator.StatModificatorType == StatModificatorType.Additive
                ? statToChange + modificator.Stat
                : statToChange * modificator.Stat;
            
            statToChange.SetStatValue(statToChange + addedValue);
            if (modificator.Duration < 0 )
                return;

            if (_activeModificators.Contains(modificator))
            {
                _activeModificators.Remove(modificator);
            }
            else
            {
                var addedStat = new Stat(modificator.Stat.Type, -addedValue);
                var tempModificator = new StatModificator(addedStat, StatModificatorType.Additive, modificator.Duration,
                    Time.time);
                _activeModificators.Add(tempModificator);
            }
        }

        private void OnUpdate()
        {
            if (_activeModificators.Count == 0)
                return;

            var expiredModificator = _activeModificators.Where(modificator =>
                modificator.StartTime + modificator.Duration >= Time.time);

            foreach (var modificator in expiredModificator)
                ProcessModificator(modificator);
        }

        public void Dispose() => ProjectUpdater.Instanse.UpdateCalled -= OnUpdate;
    }
}