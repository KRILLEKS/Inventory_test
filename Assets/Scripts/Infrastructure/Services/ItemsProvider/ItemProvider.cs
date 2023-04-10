using System;
using System.Collections.Generic;
using DerivedClasses;
using Infrastructure.Services.StaticDataProvider;
using Infrastructure.StaticData.Paths;
using Infrastructure.StaticData.ScriptableObjects;
using Inventory.Items.InventoryItem;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.ItemsProvider
{
   public class ItemProvider : IItemsProvider,
                               IInitializable
   {
      private IStaticDataProvider _staticDataProvider;

      private readonly Dictionary<Type, Dictionary<int, IItem>> _items = new ();

      [Inject]
      private void Construct(IStaticDataProvider staticDataProvider)
      {
         _staticDataProvider = staticDataProvider;
      }

      public void Initialize()
      {
         var items = _staticDataProvider.LoadAll<ItemData>(StaticDataPaths.Items);

         foreach (var item in items)
         {
            var enumTypeCompound = item.Item.GetEnumTypeCompound();
            if (_items.ContainsKey(enumTypeCompound.Type) &&
                _items[enumTypeCompound.Type].ContainsKey(enumTypeCompound.EnumRawValue))
            {
               Debug.LogError("You have duplicate of item " + item.Item.Name);
               continue;
            }

            if (_items.ContainsKey(enumTypeCompound.Type) == false)
               _items.Add(enumTypeCompound.Type, new Dictionary<int, IItem>());

            _items[enumTypeCompound.Type][enumTypeCompound.EnumRawValue] = item.Item;
         }
      }

      public IItem GetItem(EnumTypeCompound enumTypeCompound)
      {
         return _items[enumTypeCompound.Type][enumTypeCompound.EnumRawValue];
      }
   }
}