using System;
using Core.Services.Updater;
using UnityEngine;

namespace InputReader
{
    public class ExternalDeviceInputReader : IEntityInputSource, IDisposable, IWindowInputSource
    {
        public float HorizontalDirection => Input.GetAxis("Horizontal");
        public float VerticalDirection => Input.GetAxis("Vertical");
        public bool Use { get; private set; }
        
        public event Action InventoryRequested;
        public event Action InventoryClosed;

        public ExternalDeviceInputReader()
        {
            ProjectUpdater.Instanse.UpdateCalled += OnUpdate;
        }

        public void ResetOneTimeActions()
        {
            Use = false;
        }
        
        public void Dispose() => ProjectUpdater.Instanse.UpdateCalled -= OnUpdate;

        private void OnUpdate()
        {
            if (Input.GetButtonDown("Use"))
                Use = true;

            if (Input.GetKeyDown(KeyCode.E))
                InventoryRequested?.Invoke();
            
            if(Input.GetKeyDown(KeyCode.Q))
                InventoryClosed?.Invoke();
        }
    }
    
}
