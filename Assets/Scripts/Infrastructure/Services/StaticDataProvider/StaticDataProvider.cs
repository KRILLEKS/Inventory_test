﻿using UnityEngine;

namespace Infrastructure.Services.StaticDataProvider
{
   public class StaticDataProvider : IStaticDataProvider
   {
      public T Load<T>(string path) where T : Object
         => Resources.Load<T>(path);
   }
}