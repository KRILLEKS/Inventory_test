using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory
{
   public interface IUIFactory
   {
      void CreateCell(Transform parent);
      public List<GameObject> CreateCells(Transform parent, int amount);
   }
}