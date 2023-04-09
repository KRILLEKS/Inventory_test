using System;
using System.Collections.Generic;
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
      private List<CellLayout> _cellLayouts;

      [Inject]
      private void Construct(IInventoryHandler inventoryHandler)
      {
         _inventoryHandler = inventoryHandler;

         _inventoryHandler.OnSlotUpdated += UpdateSlotInfo;
      }

      public void SetCells(List<CellLayout> cells)
      {
         _cellLayouts = cells;
      }

      public void UpdateSlotInfo(Slot updatedSlot)
      {
         var cellLayout = _cellLayouts[updatedSlot.SlotIndex];

         if (cellLayout.HasItem && updatedSlot.ItemAmountInSlot == 0)
         {
            cellLayout.HasItem = false;
            DisableSlot(cellLayout, false);
         }
         else if (cellLayout.HasItem == false && updatedSlot.ItemAmountInSlot > 0)
         {
            cellLayout.HasItem = true;
            EnableSlot(cellLayout, updatedSlot.Item is IStackable);
         }
         
         if (updatedSlot.Item is IStackable)
         {
            cellLayout.AmountTMP.text = updatedSlot.ItemAmountInSlot.ToString();
            cellLayout.StackableIconRawImage.texture = updatedSlot.Item.Texture2D;
         }
         else
            cellLayout.UnstackableIconRawImage.texture = updatedSlot.Item.Texture2D;
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