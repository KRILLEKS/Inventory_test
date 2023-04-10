using System;
using System.Collections.Generic;
using Inventory.InventoryHandleRelated;

namespace Infrastructure.Serialization.Data
{
   [Serializable]
   public class SavedItem
   {
      public SavedItem(Type type, int value, List<Slot> slots)
      {
         TypeString = type.FullName;
         Value = value;

         foreach (var slot in slots)
            Slots.Add(new SavedSlot(slot));
      }

      public string TypeString;
      public int Value;
      public List<SavedSlot> Slots = new List<SavedSlot>();
   }
}