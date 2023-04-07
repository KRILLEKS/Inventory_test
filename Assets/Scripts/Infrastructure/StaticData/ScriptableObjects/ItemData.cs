using Inventory.Items.InventoryItem;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.StaticData.ScriptableObjects
{
   [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
   public class ItemData : SerializedScriptableObject
   {
      // I can also update serialized object name as I change name in the inspector (and vice versa)
      // But it goes against standard architecture rules. Although these rules can be ignored if needed :) 
      [InfoBox("I use programming by contract as a basis\n"
               + "You can change contract by right clicking instance (Item)\n"
               + "Here you have two options: Change contract or set contract to null")]
      [Tooltip("Right click to change contract")]
      [OdinSerialize]
      [HideReferenceObjectPicker]
      public IItem Item;
   }
}