using System.Collections.Generic;
using Inventory.InventoryHandleRelated;
using UnityEngine;

namespace Inventory.InventoryUIUpdater
{
   public interface IInventoryUIActualizer
   {
      public void UpdateSlotInfo(Slot updatedSlot);
      public void SetCells(List<CellLayout> cells);
   }
}