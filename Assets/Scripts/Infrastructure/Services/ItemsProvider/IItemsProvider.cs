using DerivedClasses;
using Inventory.Items.InventoryItem;

namespace Infrastructure.Services.ItemsProvider
{
   public interface IItemsProvider
   {
      public IItem GetItem(EnumTypeCompound enumTypeCompound);
   }
}