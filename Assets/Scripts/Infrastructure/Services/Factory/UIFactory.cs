using System.Collections.Generic;
using Infrastructure.Services.AssetProvider;
using Infrastructure.StaticData;
using Infrastructure.StaticData.Paths;
using Inventory.InventoryUIUpdater;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factory
{
   public class UIFactory : IUIFactory
   {
      private IAssetProvider _assetProvider;

      [Inject]
      public void Construct(IAssetProvider assetProvider)
      {
         _assetProvider = assetProvider;
      }
      
      public void CreateCell(Transform parent)
      {
         _assetProvider.Instantiate(UIPrefabPaths.CellPrefabPath, parent);
      }

      public List<GameObject> CreateCells(Transform parent, int amount)
      {
         return _assetProvider.Instantiate(UIPrefabPaths.CellPrefabPath, parent, amount);
      }
   }
}