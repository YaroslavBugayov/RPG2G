using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using InputReader;

namespace Player
{
    public class PlayerBrain : IDisposable
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;

        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
            ProjectUpdater.Instanse.FixedUpdateCalled += OnFixedUpdate;
        }

        public void OnFixedUpdate()
        {
            _playerEntity.Move(GetHorizontalDirection(), GetVerticalDirection());
            
            if (IsUse())
                _playerEntity.Use();
            
            foreach (var inputSource in _inputSources)
                inputSource.ResetOneTimeActions();    
        }

        private float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.HorizontalDirection == 0)
                    continue;

                return inputSource.HorizontalDirection;
            }

            return 0;
        }
        
        private float GetVerticalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.VerticalDirection == 0)
                    continue;

                return inputSource.VerticalDirection;
            }

            return 0;
        }

        private bool IsUse() => _inputSources.Any(source => source.Use);
        public void Dispose() => ProjectUpdater.Instanse.FixedUpdateCalled -= OnFixedUpdate;
    }
}