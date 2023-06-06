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

        private void Start()
        {
            _dropGenerator = _serviceLocator.GetService<IItemGenerator>();
        }

        public void Harvest() 
        {
            _dropGenerator.DropItem(ItemType.Apple, transform.position);
        }
    }
}