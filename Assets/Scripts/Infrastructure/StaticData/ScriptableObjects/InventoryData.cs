using Sirenix.OdinInspector;
using UnityEngine;

namespace Infrastructure.StaticData.ScriptableObjects
{
   [CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
   public class InventoryData : ScriptableObject
   {
      public int cellsAmount = 30;
      public int lockedCells = 15;
      public int newCellPrice = 150;
      
      [PropertyOrder(10)]
      [PropertySpace(spaceBefore:20)]
      [Button]
      private void ResetToDefault()
      {
         cellsAmount = 30;
         lockedCells = 15;
         newCellPrice = 150;
      }
   }
}