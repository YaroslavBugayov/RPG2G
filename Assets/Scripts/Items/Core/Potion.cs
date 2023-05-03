using Items.Data;
using Items.Enum;
using StatsSystem;

namespace Items.Core
{
    public class Potion : Item
    {
        private readonly StatsController _statsController;
        private readonly ItemDescriptor _itemDescriptor;

        private int _amount;

        public override int Amount => _amount;

        public Potion(ItemDescriptor descriptor, StatsController statsController) : base(descriptor)
        {
            _itemDescriptor = descriptor;
            _statsController = statsController;
            _amount = 1;
        }

        public override void Use()
        {
            _amount--;
            if (_amount <= 0)
                Destroy();
        }

        private void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}