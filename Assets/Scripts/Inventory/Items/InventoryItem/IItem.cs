using System;
using DerivedClasses;
using UnityEngine;

namespace Inventory.Items.InventoryItem
{
   public interface IItem
   {
      public Texture2D Texture2D { get; set; }
      public string Name { get; set; }
      public float Weight { get; set; }
      public EnumTypeCompound GetEnumTypeCompound();
   }
}