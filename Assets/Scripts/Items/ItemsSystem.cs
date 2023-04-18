using System.Collections.Generic;
using Items.Behaviour;
using Items.Core;
using Items.Data;
using UnityEngine;

namespace Items
{
    public class ItemsSystem
    {
        private SceneItem _sceneItem;
        private Transform _transform;
        private LayerMask _whatIsPlayer;
        private ItemsFactory _itemsFactory;

        private Dictionary<SceneItem, Item> _itemOnScene;

        public ItemsSystem(LayerMask whatIsPlayer, ItemsFactory itemsFactory)
        {
            //Don't see this path
            _sceneItem = Resources.Load<SceneItem>($"{nameof(ItemsSystem)}/{nameof(SceneItem)}"); 
            _itemOnScene = new Dictionary<SceneItem, Item>();
            GameObject gameObject = new GameObject();
            gameObject.name = nameof(ItemsSystem);
            _transform = gameObject.transform;
            _whatIsPlayer = whatIsPlayer;
            _itemsFactory = itemsFactory;
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
            Debug.Log($"AddingItemToInventory {item.Descriptor.ItemId}");
            _itemOnScene.Remove(sceneItem);
            sceneItem.ItemClicked -= TryPickItem;
            Object.Destroy(sceneItem);
        }
    }
}