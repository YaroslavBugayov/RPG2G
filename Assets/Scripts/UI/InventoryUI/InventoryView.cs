using System;
using System.Collections.Generic;
using System.Linq;
using Items.Core;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InventoryUI
{
    public class InventoryView : ScreenView
    {
        [SerializeField] private Button _closeButton;
        
        private IEnumerable<ItemSlot> _itemSlots;
        private Dictionary<ItemSlot, Item> _pairOfItemAndSlot;
        
        private void Awake()
        {
            _itemSlots = GetComponentsInChildren<ItemSlot>();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveAllListeners();
        }

        public void UpdateView(IEnumerable<Item> items)
        {
            _pairOfItemAndSlot = _itemSlots.Zip(items, (key, value) => new {key, value})
                .ToDictionary(x => x.key, x => x.value);

            foreach (var slot in _pairOfItemAndSlot)
            {
                ItemSlot itemSlot = slot.Key;
                Item item = slot.Value;
                
                itemSlot.SetItem(item.Descriptor.ItemSprite);
            }
        }
    }
}