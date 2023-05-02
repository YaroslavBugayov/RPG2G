using System;

namespace InputReader
{
    public interface IWindowInputSource
    { 
        event Action InventoryRequested;
        event Action InventoryClosed;
    }
}