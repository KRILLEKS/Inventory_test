using System;
using System.Linq;
using Infrastructure.Factory;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.InventoryUIUpdater;
using UnityEngine;
using Zenject;

namespace Inventory.Init
{
   public class InventorySetter : MonoBehaviour
   {
      [SerializeField] private Transform inventoryContentTransform;

      private IUIFactory _uiFactory;
      private IStaticDataProvider _staticDataProvider;
      private IInventoryUIActualizer _inventoryUIActualizer;

      private InventoryData _inventoryData;

      [Inject]
      public void Construct(IUIFactory uiFactory, IStaticDataProvider staticDataProvider, IInventoryUIActualizer inventoryUIActualizer)
      {
         _uiFactory = uiFactory;
         _staticDataProvider = staticDataProvider;
         _inventoryUIActualizer = inventoryUIActualizer;

         _inventoryData = _staticDataProvider.Load<InventoryData>(StaticDataPaths.InventoryData);
      }

      private void Awake()
      {
         ClearContent();
         CreateContent();

         void ClearContent()
         {
            for (int i = 0; i < 30; i++)
            {
               Destroy(inventoryContentTransform.GetChild(i).gameObject);
            }
         }
         void CreateContent()
         {
            // InventoryActualizer must not use .GetComponent<> or even more so .Find
            // .Find is very unstable overall cause we can rename something and then we'll need to make change in the code
            // .GetComponent is ok, but InventoryActualizer still can't use it. It's not purpose of it's class. Cause setter sets. Actualizer actualizes
            // so we kinda inject it (I like having method rather than just set value from outer scope of the class)
            var cells = _uiFactory.CreateCells(inventoryContentTransform, _inventoryData.cellsAmount);

            SetCells();

            _inventoryUIActualizer.SetCells(cells.Select(_ => _.GetComponent<CellLayout>()).ToList());

            void SetCells()
            {
               SetUnlocked();
               SetLocked();

               void SetUnlocked()
               {
                  // TODO: replace _inventoryDataSO with saved data 
                  for (var index = 0; index < _inventoryData.cellsAmount - _inventoryData.lockedCells; index++)
                  {
                     var cellLayout = cells[index].GetComponent<CellLayout>();
                     cells[index].name = $"ItemSlot_{index + 1}";
                  
                     cellLayout.UnlockedGO.SetActive(true);
                     cellLayout.LockedGO.SetActive(false);
                  
                     cellLayout.AmountTMP.gameObject.SetActive(false);
                     cellLayout.StackableIconRawImage.gameObject.SetActive(false);
                     cellLayout.UnstackableIconRawImage.gameObject.SetActive(false);
                  }
               }

               void SetLocked()
               {
                  // TODO: replace _inventoryDataSO with saved data 
                  for (var index = _inventoryData.cellsAmount - _inventoryData.lockedCells; index < _inventoryData.cellsAmount; index++)
                  {
                     var cellLayout = cells[index].GetComponent<CellLayout>();
                     cells[index].name = $"ItemSlot_{index + 1}";
                  
                     cellLayout.UnlockedGO.SetActive(false);
                     cellLayout.LockedGO.SetActive(true);
                  
                     cellLayout.AmountTMP.gameObject.SetActive(false);
                     cellLayout.StackableIconRawImage.gameObject.SetActive(false);
                     cellLayout.UnstackableIconRawImage.gameObject.SetActive(false);
                  }
               }
            }
         }
      }
   }
}