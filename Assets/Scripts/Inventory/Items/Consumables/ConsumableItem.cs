using System;
using Inventory.Items.InventoryItem;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Inventory.Items.Consumables
{
   [Serializable]
   public abstract class ConsumableItem : Item, IConsumableItem, IStackable
   {
      [Title("ItemType related")]
      [OdinSerialize]
      public int MaxStack
      {
         get;
         set;
      }
   }
}