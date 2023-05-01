using System;
using Core.Services.Updater;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Items.Behaviour
{
    public class SceneItem : MonoBehaviour
    {
        [Header("Item Sprite Settings")]
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        [Header("Item drop data")]
        [SerializeField] private float _dropRadius;
        [SerializeField] private float _dropAnimDuration;

        [SerializeField] private Transform _itemTransform;

        [field: SerializeField] public float InteractionDistance { get; private set; }
        
        public Vector2 Position => _itemTransform.position;
        
        public event Action<SceneItem> ItemClicked;

        private void Awake() => 
            _button.onClick.AddListener(() => ItemClicked?.Invoke(this));
        
        private void OnMouseDown() =>
            ItemClicked?.Invoke(this);

        private void OnDrawGizmos() => 
            Gizmos.DrawWireSphere(_itemTransform.position, InteractionDistance);

        public void PlayDrop(Vector2 position)
        {
            transform.position = position;
            Vector2 movePosition = (transform.position + new Vector3(0, Random.Range(-_dropRadius, _dropRadius), 0));
            transform.DOMove(movePosition, _dropAnimDuration);
        }
        
        public void SetItem(Sprite sprite, string itemName) 
        {
            _sprite.sprite = sprite;
            _text.text = itemName;
        }
    }
}