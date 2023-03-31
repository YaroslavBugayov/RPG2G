using System;
using Core.Services.Updater;
using UnityEngine;

namespace InputReader
{
    public class ExternalDeviceInputReader : IEntityInputSource, IDisposable
    {
        public float HorizontalDirection => Input.GetAxis("Horizontal");
        public float VerticalDirection => Input.GetAxis("Vertical");
        public bool Use { get; private set; }

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
            {
                Use = true;
            }
        }
    }
    
}
