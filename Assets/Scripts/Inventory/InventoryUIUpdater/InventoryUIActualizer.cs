using System;
using System.Collections.Generic;
using Infrastructure.Services.ItemsProvider;
using Inventory.InventoryHandleRelated;
using Inventory.Items;
using UnityEngine;
using Zenject;

namespace Inventory.InventoryUIUpdater
{
   public class InventoryUIActualizer : IInventoryUIActualizer,
                                        IDisposable
   {
      private IInventoryHandler _inventoryHandler;
      private IItemsProvider _itemsProvider;
      private List<CellLayout> _cellLayouts;

      [Inject]
      private void Construct(IInventoryHandler inventoryHandler, IItemsProvider itemsProvider)
      {
         _inventoryHandler = inventoryHandler;
         _itemsProvider = itemsProvider;

         _inventoryHandler.OnSlotUpdated += UpdateSlotInfo;
      }

      public void SetCells(List<CellLayout> cells)
      {
         _cellLayouts = cells;
      }

      public void UpdateSlotInfo(Slot updatedSlot)
      {
         var item = _itemsProvider.GetItem(updatedSlot.EnumTypeCompound);
         var cellLayout = _cellLayouts[updatedSlot.SlotIndex];

         if (cellLayout.HasItem && updatedSlot.ItemAmountInSlot == 0)
         {
            cellLayout.HasItem = false;
            DisableSlot(cellLayout, false);
         }
         else if (cellLayout.HasItem == false && updatedSlot.ItemAmountInSlot > 0)
         {
            cellLayout.HasItem = true;
            EnableSlot(cellLayout, item is IStackable);
         }
         
         if (item is IStackable)
         {
            cellLayout.AmountTMP.text = updatedSlot.ItemAmountInSlot.ToString();
            cellLayout.StackableIconRawImage.texture = item.Texture2D;
         }
         else
            cellLayout.UnstackableIconRawImage.texture = item.Texture2D;
      }

      private void DisableSlot(CellLayout cellLayout, bool isActive)
      {
         cellLayout.AmountTMP.gameObject.SetActive(false);
         cellLayout.StackableIconRawImage.gameObject.SetActive(false);
         cellLayout.UnstackableIconRawImage.gameObject.SetActive(false);
      }
      
      private void EnableSlot(CellLayout cellLayout, bool isStackable)
      {
         if (isStackable)
         {
            cellLayout.AmountTMP.gameObject.SetActive(true);
            cellLayout.StackableIconRawImage.gameObject.SetActive(true);
            cellLayout.UnstackableIconRawImage.gameObject.SetActive(false);
         }
         else
         {
            cellLayout.AmountTMP.gameObject.SetActive(false);
            cellLayout.StackableIconRawImage.gameObject.SetActive(false);
            cellLayout.UnstackableIconRawImage.gameObject.SetActive(true);
         }
      }

      public void Dispose()
      {
         _inventoryHandler.OnSlotUpdated -= UpdateSlotInfo;
      }
   }
}