using System;
using DerivedClasses;
using Sirenix.Serialization;
using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Armour.Head
{
   [Serializable]
   public class HeadArmourItem : ArmourItem, IHeadArmourItem
   {
      [OdinSerialize]
      public HeadArmourTypes HeadArmourType
      {
         get;
         set;
      }
      
      public override EnumTypeCompound GetEnumTypeCompound()
      {
         return new EnumTypeCompound((int)HeadArmourType, typeof(HeadArmourTypes));
      }
   }
}