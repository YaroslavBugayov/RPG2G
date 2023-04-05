using System;
using System.Collections.Generic;
using Core.Services.Updater;
using InputReader;
using Player;
using StatsSystem;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;

        private ExternalDeviceInputReader _externalDeviceInputReader;
        private PlayerSystem _playerSystem;
        private ProjectUpdater _projectUpdater;

        private List<IDisposable> _disposables;

        private bool _onPause = false;
        
        private void Awake()
        {
            _disposables = new List<IDisposable>();
            
            if (ProjectUpdater.Instanse == null)
                _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
            else
                _projectUpdater = ProjectUpdater.Instanse as ProjectUpdater;
            
            _externalDeviceInputReader = new ExternalDeviceInputReader();
            _disposables.Add(_externalDeviceInputReader);
            
            _playerSystem = new PlayerSystem(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDeviceInputReader
            });
            
            _disposables.Add(_playerSystem);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _projectUpdater.IsPaused = !_projectUpdater.IsPaused;
            }
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}