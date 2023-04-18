using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using InputReader;
using Items;
using Items.Data;
using Items.Storage;
using Player;
using StatsSystem;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;
        [SerializeField] private LayerMask _whatIsPlayer;
        [SerializeField] private ItemsStorage _itemsStorage;

        private ExternalDeviceInputReader _externalDeviceInputReader;
        private PlayerSystem _playerSystem;
        private ProjectUpdater _projectUpdater;
        private DropGenerator _dropGenerator;
        private ItemsSystem _itemsSystem;

        private List<IDisposable> _disposables;

        
        private void Awake()
        {
            _disposables = new List<IDisposable>();
            
            if (ProjectUpdater.Instanse == null)
                _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
            else
                _projectUpdater = ProjectUpdater.Instanse as ProjectUpdater;
            
            _externalDeviceInputReader = new ExternalDeviceInputReader();
            
            _playerSystem = new PlayerSystem(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDeviceInputReader
            });

            ItemsFactory itemsFactory = new ItemsFactory(_playerSystem.StatsController);
            _itemsSystem = new ItemsSystem(_whatIsPlayer, itemsFactory);
            List<ItemDescriptor> descriptors =
                _itemsStorage.Descriptors.Select(scriptable => scriptable.Descriptor).ToList();
            
            _dropGenerator = new DropGenerator(descriptors, _playerEntity, _itemsSystem);
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