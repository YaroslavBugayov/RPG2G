using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Locator;
using Core.Services.Updater;
using InputReader;
using Items;
using Items.Data;
using Items.Storage;
using Player;
using UI;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;
        [SerializeField] private LayerMask _whatIsPlayer;
        [SerializeField] private ItemsStorage _itemsStorage;
        [SerializeField] private UIContext _uiContext;
        [SerializeField] private ServiceLocator _serviceLocator;
        
        private ExternalDeviceInputReader _externalDeviceInputReader;
        private PlayerSystem _playerSystem;
        private ProjectUpdater _projectUpdater;
        private DropGenerator _dropGenerator;
        private ItemsSystem _itemsSystem;
        private UIContext.Data _data;

        private List<IDisposable> _disposables;

        private void Awake()
        {
            _disposables = new List<IDisposable>();
            InitializeProjectUpdater();
            _externalDeviceInputReader = new ExternalDeviceInputReader();
            InitializePlayerSystem();
            InitializeItemsSystem();
            InitializeUIContext();
            InitializeServiceLocator();
        }

        private void InitializeServiceLocator()
        {
            _serviceLocator.Initialize();
            _serviceLocator.AddService(typeof(IItemGenerator), _dropGenerator);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _projectUpdater.IsPaused = !_projectUpdater.IsPaused;
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

        private void InitializeProjectUpdater()
        {
            if (ProjectUpdater.Instanse == null)
                _projectUpdater = new GameObject()
                {
                    name = nameof(ProjectUpdater)
                }
                    .AddComponent<ProjectUpdater>();
            else
                _projectUpdater = ProjectUpdater.Instanse as ProjectUpdater;
        }

        private void InitializeItemsSystem()
        {
            _data = new UIContext.Data(new Inventory());
            ItemsFactory itemsFactory = new ItemsFactory(_playerSystem.StatsController);
            _itemsSystem = new ItemsSystem(_whatIsPlayer, itemsFactory, _data.Inventory);
            List<ItemDescriptor> descriptors =
                _itemsStorage.Descriptors.Select(scriptable => scriptable.Descriptor).ToList();

            _dropGenerator = new DropGenerator(descriptors, _playerEntity, _itemsSystem);
        }
        
        private void InitializeUIContext()
        {
            _uiContext.Initialize(new List<IWindowInputSource>()
            {
                _gameUIInputView, _externalDeviceInputReader
            }, _data);
        }

        private void InitializePlayerSystem()
        {
            _playerSystem = new PlayerSystem(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDeviceInputReader
            });
        }
    }
}