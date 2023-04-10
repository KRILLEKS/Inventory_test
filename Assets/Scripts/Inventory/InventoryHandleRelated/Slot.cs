using System;
using DerivedClasses;
using Inventory.Items;
using Inventory.Items.InventoryItem;

namespace Inventory.InventoryHandleRelated
{
   [Serializable]
   public class Slot
   {
      public Slot(EnumTypeCompound enumTypeCompound, bool isStackable, int slotIndex, int maxStack = 1)
      {
         EnumTypeCompound = enumTypeCompound;
         IsStackable = isStackable;
         SlotIndex = slotIndex;
         MaxStack = maxStack;
      }

      public EnumTypeCompound EnumTypeCompound;
      public bool IsStackable;
      public int MaxStack;
      public int ItemAmountInSlot;
      public int SlotIndex;

      // returns remainder (amount that can't fits in slot)
      public int AddItem(int amount)
      {
         if (IsStackable == false)
         {
            if (ItemAmountInSlot == 1)
               return amount;

            ItemAmountInSlot = 1;
            return --amount;
         }

         // everything fits in slot
         if (ItemAmountInSlot + amount <= MaxStack)
         {
            ItemAmountInSlot += amount;
            return 0;
         }
         // can't fit everything in slot
         else
         {
            int amount2Add = MaxStack - ItemAmountInSlot;
            ItemAmountInSlot += amount2Add;

            return amount - amount2Add;
         }
      }
   }
}