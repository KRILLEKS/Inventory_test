using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Armour.Body
{
   public interface IBodyArmourItem
   {
      public BodyArmourTypes ArmourType { get; set; }
   }
}