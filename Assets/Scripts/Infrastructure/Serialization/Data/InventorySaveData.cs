using System;
using System.Collections.Generic;
using Infrastructure.Serialization.SerializationInterfaces;
using Inventory.InventoryHandleRelated;
using Inventory.Items.InventoryItem;

namespace Infrastructure.Serialization.Data
{
   [Serializable]
   public class InventorySaveData : ISavableData
   {
      public List<SavedItem> Items = new();
      public List<int> AvailableSlotsIndexes;
      
      public InventorySaveData( Dictionary<Type, Dictionary<int, List<Slot>>> items, List<int> availableSlotsIndexes)
      {
         AvailableSlotsIndexes = availableSlotsIndexes;
         foreach (var typeDictionaryPair in items)
            foreach (var intListPair in typeDictionaryPair.Value)
            {
               Items.Add(new SavedItem(typeDictionaryPair.Key, intListPair.Key, intListPair.Value));
            }
      }

   }
}