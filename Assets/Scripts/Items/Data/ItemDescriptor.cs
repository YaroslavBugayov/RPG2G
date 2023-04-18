using System;
using Items.Enum;
using UnityEngine;

namespace Items.Data
{
    [Serializable]
    public class ItemDescriptor
    {
        [field: SerializeField] public ItemId ItemId { get; private set; }
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
        
        public ItemDescriptor(ItemId itemId, ItemType itemType, Sprite itemSprite)
        {
            ItemId = itemId;
            ItemType = itemType;
            ItemSprite = itemSprite;
        }
    }
}