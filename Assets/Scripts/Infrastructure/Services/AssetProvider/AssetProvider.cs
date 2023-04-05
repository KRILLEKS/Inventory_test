using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
   public class AssetProvider : IAssetProvider
   {
      public GameObject Instantiate(string path)
      {
         var prefab = Resources.Load<GameObject>(path);
         return Object.Instantiate(prefab);
      }
      
      public GameObject Instantiate(string path, Transform parent)
      {
         var prefab = Resources.Load<GameObject>(path);
         return Object.Instantiate(prefab, parent);
      }
      
      public List<GameObject> Instantiate(string path, Transform parent, int amount)
      {
         var buffer = new List<GameObject>();
         var prefab = Resources.Load<GameObject>(path);

         for (int i = 0; i < amount; i++)
            buffer.Add(Object.Instantiate(prefab, parent));

         return buffer;
      }
   }
}
