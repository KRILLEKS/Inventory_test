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

         if (cellLayout.HasItem == false)
            ChangeSlotState(updatedSlot);

         if (updatedSlot.Item is IStackable)
         {
            cellLayout.AmountTMP.text = updatedSlot.ItemAmountInSlot.ToString();
            cellLayout.StackableIconRawImage.texture = updatedSlot.Item.Texture2D;
         }
         else
            cellLayout.UnstackableIconRawImage.texture = updatedSlot.Item.Texture2D;
      }

      private void ChangeSlotState(Slot slot)
      {
         var cellLayout = _cellLayouts[slot.SlotIndex];
         var hasItemInverted = cellLayout.HasItem == false;

         if (slot.Item is IStackable)
         {
            cellLayout.AmountTMP.gameObject.SetActive(hasItemInverted);
            cellLayout.UnstackableIconRawImage.gameObject.SetActive(cellLayout.HasItem);
            cellLayout.StackableIconRawImage.gameObject.SetActive(hasItemInverted);
         }
         else
         {
            cellLayout.AmountTMP.gameObject.SetActive(cellLayout.HasItem);
            cellLayout.UnstackableIconRawImage.gameObject.SetActive(hasItemInverted);
            cellLayout.StackableIconRawImage.gameObject.SetActive(cellLayout.HasItem);
         }

         cellLayout.HasItem = hasItemInverted;
      }

      public void Dispose()
      {
         _inventoryHandler.OnSlotUpdated -= UpdateSlotInfo;
      }
   }
}