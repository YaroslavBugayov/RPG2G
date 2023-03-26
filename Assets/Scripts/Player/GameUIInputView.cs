using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _inventoryButton;
        
        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
        public bool Use { get; private set; }

        private void Awake()
        {
            _useButton.onClick.AddListener(() => Use = true);
        }

        private void OnDestroy()
        {
            _useButton.onClick.RemoveAllListeners();
        }
        
        public void ResetOneTimeActions()
        {
            Use = false;
        }
    }
}