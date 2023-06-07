using System;
using Core.Services.Locator;
using Items;
using Items.Enum;
using UnityEngine;

namespace Environment
{
    public class Tree : MonoBehaviour
    {
        [SerializeField] private ServiceLocator _serviceLocator;
    
        private IItemGenerator _dropGenerator;
        private bool _hasHarvest = true;
        private Sprite _hasHarvestSprite;
        private Sprite _hasNotHarvestSprite;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _hasHarvestSprite = Resources.Load<Sprite>("SpriteStates/Tree/TreeHasHarvest");
            _hasNotHarvestSprite = Resources.Load<Sprite>("SpriteStates/Tree/TreeHasNotHarvest");
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _dropGenerator = _serviceLocator.GetService<IItemGenerator>();
        }

        public void Harvest()
        {
            if (_hasHarvest)
            {
                _dropGenerator.DropItem(ItemType.Apple, transform.position);
                _spriteRenderer.sprite = _hasNotHarvestSprite;
            }

            _hasHarvest = false;
        }
    }
}
