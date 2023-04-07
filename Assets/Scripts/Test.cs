using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.StaticData.Enums.InventoryItems;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.Items;
using Inventory.Items.InventoryItem;
using UnityEngine;

public class Test : MonoBehaviour
{
   [SerializeField] private bool enable;

   private void Awake()
   {
      if (enable == false)
         return;

      var items = Resources.LoadAll<ItemData>("ScriptableObjects/Items");

      foreach (var item in items)
      {
         // this is how we can use items
         if (item.Item is IStackable)
            Debug.Log($"{item.name} is stackable");
      }
   }
}