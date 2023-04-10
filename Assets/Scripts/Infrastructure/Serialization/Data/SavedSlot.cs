using System;
using Inventory.InventoryHandleRelated;
using Inventory.Items;

namespace Infrastructure.Serialization.Data
{
   [Serializable]
   public class SavedSlot
   {
      public SavedSlot(Slot slot)
      {
         TypeString = slot.EnumTypeCompound.Type.FullName;
         Value = slot.EnumTypeCompound.EnumRawValue;
         IsStackable = slot.IsStackable;
         MaxStack = slot.MaxStack;
         ItemAmountInSlot = slot.ItemAmountInSlot;
         SlotIndex = slot.SlotIndex;
      }
      
      public string TypeString;
      public int Value;
      public bool IsStackable;
      public int MaxStack;
      public int ItemAmountInSlot;
      public int SlotIndex;
   }
}