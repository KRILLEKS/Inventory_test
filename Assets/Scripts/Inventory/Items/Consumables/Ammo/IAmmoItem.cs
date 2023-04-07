using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Consumables.Ammo
{
   public interface IAmmoItem
   {
      public AmmoTypes AmmoType { get; set; }
   }
}