using System;
using System.Drawing;
using DerivedClasses;
using Infrastructure.StaticData.Enums.InventoryItems;
using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;
using Inventory.Items.InventoryItem;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Inventory.Items.Weapon
{
   [Serializable]
   public class WeaponItem : Item,
                             IWeaponItem
   {
      [Title("ItemType related")]
      [OdinSerialize]
      public WeaponTypes WeaponType
      {
         get;
         set;
      }

      [OdinSerialize]
      public AmmoTypes AmmoType
      {
         get;
         set;
      }

      [OdinSerialize]
      public float Damage
      {
         get;
         set;
      }

      [InfoBox("0 means there is no reload time", InfoMessageType.None)]
      [OdinSerialize]
      public float ReloadSpeed
      {
         get;
         set;
      }
      
      public override EnumTypeCompound GetEnumTypeCompound()
      {
         return new EnumTypeCompound((int)WeaponType, typeof(WeaponTypes));
      }
   }
}