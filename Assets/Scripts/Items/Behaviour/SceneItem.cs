using System;
using Core.Services.Updater;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Behaviour
{
    public class SceneItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        [SerializeField] private Canvas _canvas;

        public event Action<SceneItem> ItemClicked;

        private void Awake() => _button.onClick.AddListener(() => ItemClicked?.Invoke(this));
        private void OnMouseDown() => ItemClicked?.Invoke(this);

        public void SetItem(Sprite sprite, string itemName)
        {
            _sprite.sprite = sprite;
            _text.text = itemName;
        }
    }
}