using System.Collections.Generic;
using System.Linq;
using Core.Services.Locator;
using Core.Services.Updater;
using Items.Data;
using Items.Enum;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class DropGenerator : IItemGenerator
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<ItemDescriptor> _itemDescriptors;
        private readonly ItemsSystem _itemsSystem;

        public DropGenerator(List<ItemDescriptor> itemDescriptors, PlayerEntity playerEntity, ItemsSystem itemsSystem)
        {
            _playerEntity = playerEntity;
            _itemDescriptors = itemDescriptors;
            _itemsSystem = itemsSystem;
            ProjectUpdater.Instanse.UpdateCalled += Update;
        }

        public void DropItem(ItemType itemType, Vector2 position)
        {
            var itemDescriptor = _itemDescriptors.Find(item => item.ItemType == itemType);
            _itemsSystem.DropItem(itemDescriptor, position);
        }

        private void DropRandomItem()
        {
            List<ItemDescriptor> items = _itemDescriptors.ToList();
            ItemDescriptor itemDescriptor = items[Random.Range(0, items.Count())];
            _itemsSystem.DropItem(itemDescriptor, _playerEntity.transform.position + Vector3.one);
        }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.G))
                DropRandomItem();
        }
    }

    public interface IItemGenerator : IService
    {
        void DropItem(ItemType itemType, Vector2 position);
    }
}





















