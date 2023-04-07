using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Armour.Head
{
   public interface IHeadArmourItem
   {
      public HeadArmourTypes HeadArmourType { get; set; }
   }
}