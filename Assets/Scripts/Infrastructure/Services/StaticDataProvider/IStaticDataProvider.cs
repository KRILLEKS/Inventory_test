using UnityEngine;

namespace Infrastructure.Services.StaticDataProvider
{
   public interface IStaticDataProvider
   {
      public T Load<T>(string path) where T : Object;
      public T[] LoadAll<T>(string path) where T : Object;
   }
}