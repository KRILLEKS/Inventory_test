﻿using System.Collections.Generic;

namespace Extension
{
   public static class Extensions
   {
      public static T Random<T>(this List<T> list)
      {
         return list[UnityEngine.Random.Range(0, list.Count)];
      }
   }
}