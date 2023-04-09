using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.StaticData.Enums.InventoryItems;

namespace Extension
{
   public static class Extensions
   {
      public static T1 RandomKey<T1, T2>(this Dictionary<T1,T2> dictionary)
      {
         return dictionary.Keys.ToList().Random();
      }
      
      public static T Random<T>(this List<T> list)
      {
         return list[UnityEngine.Random.Range(0, list.Count)];
      }
      
      public static List<T> RemoveLast<T>(this List<T> list)
      {
         list.RemoveAt(list.Count - 1);
         return list;
      }

      public static int Random<T>(this T @enum) where T : Enum
      {
         var allValues = Enum.GetValues(@enum.GetType()).Cast<int>().ToList();
         return allValues.Random();
      }
   }
}