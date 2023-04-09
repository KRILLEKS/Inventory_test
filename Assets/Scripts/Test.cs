using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extension;
using Infrastructure.StaticData.Enums.InventoryItems;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.InventoryHandleRelated;
using Inventory.Items;
using Inventory.Items.InventoryItem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   [SerializeField] private bool enable;

   private IInventoryHandler _inventoryHandler;

   [Inject]
   public void Construct(IInventoryHandler inventoryHandler)
   {
      _inventoryHandler = inventoryHandler;
   }
   
   private void Awake()
   {
      if (enable == false)
         return;
   }

   [Button]
   private void AddItem2Inventory(ItemData itemData, int amount)
   {
      _inventoryHandler.AddItem(itemData.Item, amount);
   }

   [Button]
   private void RemoveItemFromInventory(ItemData itemData, int amount)
   {
      _inventoryHandler.RemoveItem(itemData.Item, amount);
   }

   private void GetAllStackableItems()
   {
      var items = Resources.LoadAll<ItemData>("ScriptableObjects/Items");

      foreach (var item in items)
      {
         // this is how we can use items
         if (item.Item is IStackable)
            Debug.Log($"{item.name} is stackable");
      }
   }
}