
// have method for each button. Basically just needed to test functionality

using System;
using System.Linq;
using Extension;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Enums.InventoryItems;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.Items;
using Inventory.Items.Consumables.Ammo;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Inventory.InventoryHandleRelated
{
   public class ButtonAssistedInventory : InventoryHandler, IButtonAssistedInventory
   {
      private IStaticDataProvider _staticDataProvider;
      
      private ItemEnums.AmmoTypes ammo;

      [Inject]
      private void Construct(IStaticDataProvider staticDataProvider)
      {
         _staticDataProvider = staticDataProvider;
      }

      // we can replace ammo.Random but I thought it's nice to have something like this. Convenient for me
      public void Shoot()
      {
         // any ammo (even if we don't have some types of ammo)
         // RemoveItem(typeof(ItemEnums.AmmoTypes),ammo.Random(), 1);
         
         // random ammo which we have
         var type = typeof (ItemEnums.AmmoTypes);
         if (_items.ContainsKey(type) == false)
         {
            Debug.Log("You don't have ammo at all");
            return;
         }
         
         RemoveItem(type, _items[type].RandomKey(), 1);
      }

      public void AddAmmo()
      {
         foreach (var ammoData in _staticDataProvider.LoadAll<ItemData>(StaticDataPaths.AmmoData))
         {
            AddItem(ammoData.Item, ((IStackable) ammoData.Item).MaxStack);
         }
      }

      public void AddAllItems()
      {
         foreach (var itemData in _staticDataProvider.LoadAll<ItemData>(StaticDataPaths.BodyArmourData))
            AddItem(itemData.Item);
         
         foreach (var itemData in _staticDataProvider.LoadAll<ItemData>(StaticDataPaths.HeadArmourData))
            AddItem(itemData.Item);
         
         foreach (var itemData in _staticDataProvider.LoadAll<ItemData>(StaticDataPaths.WeaponData))
            AddItem(itemData.Item);
      }

      public void DeleteRandom()
      {
         var type = _items.RandomKey();
         var value = _items[type].RandomKey();
         RemoveItem(type, value, _items[type][value][^1].ItemAmountInSlot);
      }
   }
}
