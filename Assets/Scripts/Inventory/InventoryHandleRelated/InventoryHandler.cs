using System;
using System.Collections.Generic;
using DerivedClasses;
using Extension;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.Items.InventoryItem;
using UnityEngine;
using Zenject;

namespace Inventory.InventoryHandleRelated
{
   public class InventoryHandler : IInventoryHandler, IInitializable
   {
      public Action<Slot> OnSlotUpdated
      {
         get;
         set;
      }
      
      private readonly Dictionary<Type, Dictionary<int, List<Slot>>> _items = new (); // type(enum) - subtype(enumValue) - slot
      private readonly List<int> _availableSlotsIndexes = new (); // must be loaded
      
      public void Initialize()
      {
         for (int i = 0; i < 15; i++)
         {
            _availableSlotsIndexes.Add(i);
         }
      }
      
      public void AddItem(IItem item, int amount = 1)
      {
         var itemType = item.GetEnumTypeCompound().Type;
         var itemEnumValue = item.GetEnumTypeCompound().EnumRawValue;

         if (CheckIfHasSpace() == false)
            return;

         AddItemsIfAble();

         // return true if any free space left
         bool CheckIfHasSpace()
         {
            if (_items.ContainsKey(itemType) == false
                || _items[itemType].ContainsKey(itemEnumValue) == false)
               return AddNewSlot();

            return true;
         }
         void AddItemsIfAble()
         {
            int remainingAmount = amount;
            AddItem2Slot();
            
            while (remainingAmount > 0)
            {
               if (AddNewSlot() == false)
                  return;

               AddItem2Slot();
            }

            void AddItem2Slot()
            {
               remainingAmount = _items[itemType][itemEnumValue][^1].AddItem(remainingAmount);
               // this can be replaced with custom dictionary (I just invoke it directly)
               OnSlotUpdated.Invoke(_items[itemType][itemEnumValue][^1]);
            }
         }
         // return true if was able to add new slot
         bool AddNewSlot()
         {
            if (_availableSlotsIndexes.Count == 0)
            {
               Debug.LogWarning("Inventory is full");
               return false;
            }

            if (_items.ContainsKey(itemType) == false)
               _items.Add(itemType, new Dictionary<int, List<Slot>>());
            if (_items[itemType].ContainsKey(itemEnumValue) == false)
               _items[itemType].Add(itemEnumValue, new List<Slot>());

            int slotIndex = _availableSlotsIndexes.Random();
            _items[itemType][itemEnumValue].Add(new Slot(item, slotIndex));
            
            _availableSlotsIndexes.Remove(slotIndex);
            return true;
         }
      }
   }
}