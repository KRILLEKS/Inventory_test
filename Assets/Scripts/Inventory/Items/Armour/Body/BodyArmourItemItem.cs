using System;
using DerivedClasses;
using Sirenix.Serialization;
using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Armour.Body
{
   [Serializable]
   public class BodyArmourItem : ArmourItem,
                             IBodyArmourItem
   {
      [OdinSerialize]
      public BodyArmourTypes ArmourType
      {
         get;
         set;
      }

      public override EnumTypeCompound GetEnumTypeCompound()
      {
         return new EnumTypeCompound((int)ArmourType, typeof(BodyArmourTypes));
      }
   }
}