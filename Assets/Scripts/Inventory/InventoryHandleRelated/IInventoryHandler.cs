using System;
using Inventory.Items.InventoryItem;

namespace Inventory.InventoryHandleRelated
{
   public interface IInventoryHandler
   {
      public Action<Slot> OnSlotUpdated { get; set; }
      public void AddItem(IItem item, int amount = 1);
      public bool RemoveItem(IItem item, int amount = 1);
   }
}