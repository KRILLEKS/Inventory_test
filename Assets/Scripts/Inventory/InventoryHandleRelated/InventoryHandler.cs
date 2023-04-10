using System;
using System.Collections.Generic;
using System.Linq;
using DerivedClasses;
using Extension;
using Infrastructure.Serialization.Data;
using Infrastructure.Serialization.SerializationInterfaces;
using Infrastructure.Serialization.SerializationServices;
using Infrastructure.Services.ItemsProvider;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.Items;
using Inventory.Items.InventoryItem;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Inventory.InventoryHandleRelated
{
   public class InventoryHandler : IInventoryHandler,
                                   ISavable
   {
      public ISaveLoadService _saveLoadService
      {
         get;
         set;
      }

      private IItemsProvider _itemsProvider;

      public Action<Slot> OnSlotUpdated
      {
         get;
         set;
      }

      internal Dictionary<Type, Dictionary<int, List<Slot>>> _items = new (); // type(enum) - subtype(enumValue) - slot
      internal List<int> _availableSlotsIndexes = new (); // must be loaded

      [Inject]
      private void Construct(ISaveLoadService saveLoadService, IItemsProvider itemsProvider)
      {
         _saveLoadService = saveLoadService;
         _itemsProvider = itemsProvider;
      }

      public void Initialize()
      {
         Load();
      }

      public void Load()
      {
         var inventorySaveData = _saveLoadService?.Read<InventorySaveData>(SaveDataPaths.InventoryData);
         if (inventorySaveData == null)
         {
            for (int i = 0; i < 15; i++)
               _availableSlotsIndexes.Add(i);
            return;
         }
         
         _availableSlotsIndexes = inventorySaveData.AvailableSlotsIndexes;

         foreach (var savedItem in inventorySaveData.Items)
            foreach (var slot in savedItem.Slots)
            {
               var typeEnumCompound = new EnumTypeCompound(slot.Value, Type.GetType(slot.TypeString));
               var itemType = typeEnumCompound.Type;
               var itemEnumValue = typeEnumCompound.EnumRawValue;
               
               if (_items.ContainsKey(itemType) == false)
                  _items.Add(itemType, new Dictionary<int, List<Slot>>());
               if (_items[itemType].ContainsKey(itemEnumValue) == false)
                  _items[itemType].Add(itemEnumValue, new List<Slot>());

               _items[itemType][itemEnumValue].Add(new Slot(typeEnumCompound, slot.IsStackable, slot.SlotIndex, slot.MaxStack));
               _items[itemType][itemEnumValue][^1].ItemAmountInSlot = slot.ItemAmountInSlot;
               OnSlotUpdated.Invoke(_items[itemType][itemEnumValue][^1]);
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
            _items[itemType][itemEnumValue]
               .Add(new Slot(item.GetEnumTypeCompound(),
                             item is IStackable,
                             slotIndex,
                             (item is IStackable stackable) ? stackable.MaxStack : 1));

            _availableSlotsIndexes.Remove(slotIndex);
            return true;
         }
      }

      // returns true if was able to remove item. Returns false if not enough items of this type
      public bool RemoveItem(Type itemEnumType, int itemEnumValue, int amount = 1)
      {
         if (CheckIfHaveThisItem() == false
             || CheckIfHaveEnoughItem() == false)
         {
            Debug.Log("You don't have enough items");
            return false;
         }

         RemoveItemsFromInventory();
         return true;

         bool CheckIfHaveThisItem()
         {
            if (_items.ContainsKey(itemEnumType) == false
                || _items[itemEnumType].ContainsKey(itemEnumValue) == false)
               return false;

            return true;
         }
         bool CheckIfHaveEnoughItem()
         {
            return _items[itemEnumType][itemEnumValue].Sum(_ => _.ItemAmountInSlot) >= amount;
         }
         void RemoveItemsFromInventory()
         {
            int remainingAmount = amount;
            while (remainingAmount > 0)
            {
               var slot = _items[itemEnumType][itemEnumValue][^1];

               if (slot.ItemAmountInSlot >= remainingAmount)
               {
                  slot.ItemAmountInSlot -= remainingAmount;
                  OnSlotUpdated(slot);

                  if (slot.ItemAmountInSlot == 0)
                     RemoveLastSlot(itemEnumType, itemEnumValue);

                  return;
               }

               remainingAmount -= slot.ItemAmountInSlot;
               slot.ItemAmountInSlot = 0;
               OnSlotUpdated(slot);
               RemoveLastSlot(itemEnumType, itemEnumValue);
            }
         }

         void RemoveLastSlot(Type enumType, int enumValue)
         {
            _availableSlotsIndexes.Add(_items[enumType][enumValue][^1].SlotIndex);
            _items[enumType][enumValue].RemoveLast();

            if (_items[enumType][enumValue].Count == 0)
               _items[enumType].Remove(enumValue);

            if (_items[enumType].Count == 0)
               _items.Remove(enumType);
         }
      }

      public bool RemoveItem(IItem type, int amount = 1)
      {
         return RemoveItem(type.GetEnumTypeCompound().Type, type.GetEnumTypeCompound().EnumRawValue, amount);
      }

      public void Save()
      {
         _saveLoadService.Write(SaveDataPaths.InventoryData, new InventorySaveData(_items, _availableSlotsIndexes));
      }

      public void Dispose()
      {
         Save();
      }
   }
}