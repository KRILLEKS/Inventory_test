using System.Collections;
using System.Collections.Generic;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.InventoryHandleRelated;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

// this is a bad code. Cause it's made just to test functionality
[TypeInfoBox("this is a bad code. Cause it's made just to test functionality")]
public class InventoryButtons : MonoBehaviour
{
   private IButtonAssistedInventory _inventoryHandler;

   [Inject]
   private void Construct(IButtonAssistedInventory inventoryHandler)
   {
      _inventoryHandler = inventoryHandler;
   }

   public void Shoot()
   {
      _inventoryHandler.Shoot();
   }

   public void AddAmmo()
   {
      _inventoryHandler.AddAmmo();
   }

   public void AddAllItems()
   {
      _inventoryHandler.AddAllItems();
   }

   public void RemoveRandom()
   {
      _inventoryHandler.DeleteRandom();
   }
}
