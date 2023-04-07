using System;
using Inventory.Items.InventoryItem;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Inventory.Items.Armour
{
   [Serializable]
   public abstract class ArmourItem : Item, IArmourItem
   {
      [Title("ItemType related")]
      [OdinSerialize]
      public float ArmourAmount
      {
         get;
         set;
      }
   }
}