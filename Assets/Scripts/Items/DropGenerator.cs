using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using Items.Data;
using Player;
using UnityEngine;

namespace Items
{
    public class DropGenerator
    {
        private PlayerEntity _playerEntity;
        private List<ItemDescriptor> _itemDescriptors;
        private ItemsSystem _itemsSystem;

        public DropGenerator(List<ItemDescriptor> itemDescriptors, PlayerEntity playerEntity, ItemsSystem itemsSystem)
        {
            _playerEntity = playerEntity;
            _itemDescriptors = itemDescriptors;
            _itemsSystem = itemsSystem;
            ProjectUpdater.Instanse.UpdateCalled += Update;
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
}





















