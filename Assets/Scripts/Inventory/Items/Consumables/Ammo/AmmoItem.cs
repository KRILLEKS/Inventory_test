using System;
using DerivedClasses;
using Infrastructure.StaticData.Enums.InventoryItems;
using Sirenix.Serialization;

namespace Inventory.Items.Consumables.Ammo
{
   [Serializable]
   public class AmmoItem : ConsumableItem, IAmmoItem
   {
      [OdinSerialize]
      public ItemEnums.AmmoTypes AmmoType
      {
         get;
         set;
      }
      
      public override EnumTypeCompound GetEnumTypeCompound()
      {
         return new EnumTypeCompound((int)AmmoType, typeof(ItemEnums.AmmoTypes));
      }
   }
}