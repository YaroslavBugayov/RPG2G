using System.Collections.Generic;
using Items.Behaviour;
using Items.Core;
using Items.Data;
using UnityEngine;

namespace Items
{
    public class ItemsSystem
    {
        private readonly SceneItem _sceneItem;
        private readonly Transform _transform;
        private readonly LayerMask _whatIsPlayer;
        private readonly ItemsFactory _itemsFactory;
        private readonly Dictionary<SceneItem, Item> _itemOnScene;
        private readonly Inventory _inventory;

        public ItemsSystem(LayerMask whatIsPlayer, ItemsFactory itemsFactory, Inventory inventory)
        {
            _sceneItem = Resources.Load<SceneItem>($"{nameof(ItemsSystem)}/{nameof(SceneItem)}"); 
            _itemOnScene = new Dictionary<SceneItem, Item>();
            GameObject gameObject = new GameObject
            {
                name = nameof(ItemsSystem)
            };
            _transform = gameObject.transform;
            _whatIsPlayer = whatIsPlayer;
            _itemsFactory = itemsFactory;
            _inventory = inventory;
        }
        
        public void DropItem(ItemDescriptor descriptor, Vector2 position)
        {
            DropItem(_itemsFactory.CreateItem(descriptor), position);
        }
        
        private void DropItem(Item item, Vector2 position)
        {
            SceneItem sceneItem = Object.Instantiate(_sceneItem, _transform);
            sceneItem.SetItem(item.Descriptor.ItemSprite, item.Descriptor.ItemId.ToString());
            sceneItem.PlayDrop(position);
            sceneItem.ItemClicked += TryPickItem;
            _itemOnScene.Add(sceneItem, item);
        }
        

        private void TryPickItem(SceneItem sceneItem)
        {
            Collider2D player = 
                Physics2D.OverlapCircle(sceneItem.Position, sceneItem.InteractionDistance, _whatIsPlayer);
            if(player == null)
                return;
            Item item = _itemOnScene[sceneItem];
            _inventory.AddItem(item);
            _itemOnScene.Remove(sceneItem);
            sceneItem.ItemClicked -= TryPickItem;
            Object.Destroy(sceneItem.gameObject);
        }
    }
}