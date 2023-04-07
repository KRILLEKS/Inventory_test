using System;
using Infrastructure.StaticData.Enums.InventoryItems;
using Sirenix.Serialization;

namespace Inventory.Items.Armour.Head
{
   [Serializable]
   public class HeadArmourItem : ArmourItem, IHeadArmourItem
   {
      [OdinSerialize]
      public ItemEnums.HeadArmourTypes HeadArmourType
      {
         get;
         set;
      }
   }
}