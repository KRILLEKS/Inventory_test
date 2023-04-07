using Inventory.Items;
using Inventory.Items.InventoryItem;

namespace Inventory.InventoryHandleRelated
{
   public class Slot
   {
      public Slot(IItem item, int slotIndex)
      {
         Item = item;
         SlotIndex = slotIndex;
      }

      public IItem Item;
      public int ItemAmountInSlot;
      public int SlotIndex;

      // returns remainder (amount that can't fits in slot)
      public int AddItem(int amount)
      {
         if (Item is IStackable == false)
         {
            if (ItemAmountInSlot == 1)
               return amount;

            ItemAmountInSlot = 1;
            return --amount;
         }

         var maxStack = ((IStackable) Item).MaxStack;
         // everything fits in slot
         if (ItemAmountInSlot + amount <= maxStack)
         {
            ItemAmountInSlot += amount;
            return 0;
         }
         // can't fit everything in slot
         else
         {
            int amount2Add = maxStack - ItemAmountInSlot;
            ItemAmountInSlot += amount2Add;

            return amount - amount2Add;
         }
      }
   }
}