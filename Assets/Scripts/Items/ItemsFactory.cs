using System;
using Items.Core;
using Items.Data;
using Items.Enum;
using StatsSystem;

namespace Items
{
    public class ItemsFactory
    {
        private readonly StatsController _statsController;
        public ItemsFactory(StatsController statsController) => _statsController = statsController;

        public Item CreateItem(ItemDescriptor descriptor)
        {
            return descriptor.ItemType switch
            {
                ItemType.Axe => new Potion(descriptor, _statsController),
                ItemType.WateringCan => new Potion(descriptor, _statsController),
                ItemType.Apple => new Potion(descriptor, _statsController),
                _ => throw new NullReferenceException($"Item type {descriptor.ItemType} is not implemented yet")
            };
        }

        private ItemType GetItemType(ItemDescriptor descriptor)
        {
            switch (descriptor.ItemType)
            {
                case ItemType.Axe:
                    return ItemType.Axe;
                case ItemType.WateringCan:
                    return ItemType.WateringCan;
                default:
                    return ItemType.None;
            }
        }
    }
}