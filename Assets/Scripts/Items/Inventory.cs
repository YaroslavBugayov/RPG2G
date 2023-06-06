using System;
using System.Collections.Generic;
using Items.Core;
using UI.Core;
using UnityEngine;

namespace Items
{
    public class Inventory : IModel
    {
        private const int MaxSize = 8;
        
        private readonly List<Item> _items;

        public IEnumerable<Item> Items => _items;

        public event Action<IEnumerable<Item>> ItemsChanged;

        public Inventory()
        {
            _items = new List<Item>(MaxSize);
        }

        public void AddItem(Item item)
        {
            if (_items.Count + 1 > MaxSize)
                throw new ArgumentException("Wrong Action! You can't add Item!");

            _items.Add(item);
            ItemsChanged?.Invoke(Items);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            ItemsChanged?.Invoke(Items);
        }
    }
}