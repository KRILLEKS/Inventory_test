using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
   public interface IAssetProvider
   {
      GameObject Instantiate(string path);
      GameObject Instantiate(string path, Transform parent);
      public List<GameObject> Instantiate(string path, Transform parent, int amount);
   }
}