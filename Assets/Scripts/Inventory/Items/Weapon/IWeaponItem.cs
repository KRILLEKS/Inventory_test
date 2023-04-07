using Sirenix.OdinInspector;
using static Infrastructure.StaticData.Enums.InventoryItems.ItemEnums;

namespace Inventory.Items.Weapon
{
   public interface IWeaponItem
   {
      public WeaponTypes WeaponType { get; set; }
      public AmmoTypes AmmoType { get; set; }
      public float Damage { get; set; }
      public float ReloadSpeed { get; set; }
   }
}