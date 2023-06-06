using System.Collections.Generic;
using InputReader;
using Items;
using UI.Core;
using UI.InventoryUI;
using UnityEngine;

namespace UI
{
    public class UIContext : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        private List<IWindowInputSource> _inputSources;
        private IScreenPresenter _currentScreenPresenter;

        public void Initialize(List<IWindowInputSource> inputSources, Data data)
        {
            _inputSources = inputSources;
            foreach (var windowInputSource in _inputSources)
            {
                windowInputSource.InventoryRequested += OpenInventory;
                windowInputSource.InventoryClosed += CloseCurrentScreen;
            }

            _currentScreenPresenter = new InventoryPresenter(_inventoryView, data.Inventory);
        }
        

        private void OnDestroy()
        {
            foreach (var windowInputSource in _inputSources)
            {
                windowInputSource.InventoryRequested -= OpenInventory;
                windowInputSource.InventoryClosed -= CloseCurrentScreen;
            }
            _currentScreenPresenter.OnDestroy();
        }

        private void OpenInventory() => _currentScreenPresenter.Initialize();

        private void CloseCurrentScreen() => _currentScreenPresenter.Complete();
        
        public class Data
        {
            public Inventory Inventory { get; }

            public Data(Inventory inventory)
            {
                Inventory = inventory;
            }
        }
    }
}
