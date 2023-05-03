using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InventoryUI
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _elementImage;
        [SerializeField] private Image _background;
        [Header("Slot Full/Empty")]
        [SerializeField] private Sprite _fullSlot;
        [SerializeField] private Sprite _emptySlot;

        public void SetItem(Sprite itemSprite)
        {
            _background.sprite = _fullSlot;
            _elementImage.sprite = itemSprite;
            _elementImage.enabled = true;
        }

        public void ClearItem()
        {
            _background.sprite = _emptySlot;
            _elementImage.sprite = null;
        }
    }
}