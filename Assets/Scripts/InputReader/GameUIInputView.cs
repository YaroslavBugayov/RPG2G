using System;
using UnityEngine;
using UnityEngine.UI;

namespace InputReader
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource, IWindowInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _inventoryButton;
        
        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
        public bool Use { get; private set; }
        
        public event Action InventoryRequested;
        public event Action InventoryClosed;

        private void Awake()
        {
            _useButton.onClick.AddListener(() => Use = true);
            _inventoryButton.onClick.AddListener(() => InventoryRequested?.Invoke());
        }

        private void OnDestroy()
        {
            _useButton.onClick.RemoveAllListeners();
            _inventoryButton.onClick.RemoveAllListeners();
        }
        
        public void ResetOneTimeActions()
        {
            Use = false;
        }
    }
}