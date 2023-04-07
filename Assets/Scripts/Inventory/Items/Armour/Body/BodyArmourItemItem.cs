using System;
using Infrastructure.StaticData.Enums.InventoryItems;
using Sirenix.Serialization;

namespace Inventory.Items.Armour.Body
{
   [Serializable]
   public class BodyArmourItem : ArmourItem,
                             IBodyArmourItem
   {
      [OdinSerialize]
      public ItemEnums.BodyArmourTypes ArmourType
      {
         get;
         set;
      }
   }
}