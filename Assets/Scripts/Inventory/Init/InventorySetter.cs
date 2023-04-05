using System;
using Infrastructure.Factory;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Inventory.Init
{
    public class InventorySetter : MonoBehaviour
    {
        [SerializeField] private Transform inventoryContentTransform;

        private IUIFactory _uiFactory;
        private IStaticDataProvider _staticDataProvider;
        private InventoryData _inventoryData;

        [Inject]
        public void Construct(IUIFactory uiFactory, IStaticDataProvider staticDataProvider)
        {
            _uiFactory = uiFactory;
            _staticDataProvider = staticDataProvider;

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
                _uiFactory.CreateCells(inventoryContentTransform, _inventoryData.cellsAmount);
            }
        }
    }
}
