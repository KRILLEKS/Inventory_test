using System;
using DerivedClasses;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Inventory.Items.InventoryItem
{
   [Serializable]
   public abstract class Item : IItem
   {
      [Title("Essentials")]
      [PropertyOrder(-10)]
      [OdinSerialize]
      [PreviewField(Alignment = ObjectFieldAlignment.Left)]
      public Texture2D Texture2D
      {
         get;
         set;
      }
      
      [OdinSerialize]
      public string Name
      {
         get;
         set;
      }

      [OdinSerialize]
      public float Weight
      {
         get;
         set;
      }

      public virtual EnumTypeCompound GetEnumTypeCompound()
      {
         throw new NotImplementedException();
      }
   }
}