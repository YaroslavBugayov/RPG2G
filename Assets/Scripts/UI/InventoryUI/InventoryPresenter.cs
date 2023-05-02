using System;
using Items;
using UI.Core;

namespace UI.InventoryUI
{
    public class InventoryPresenter : ScreenPresenter<InventoryView, Inventory>
    {
        public InventoryPresenter(InventoryView inventoryView, Inventory inventory) : base(inventoryView, inventory)
        {
            Model.ItemsChanged += View.UpdateView;
        }

        public override void OnDestroy()
        {
            Model.ItemsChanged -= View.UpdateView;
        }
        
    }
}