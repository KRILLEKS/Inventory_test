using System.IO;
using Infrastructure.Serialization.SerializationInterfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.Serialization.SerializationServices
{
   public class JsonSerializer : IJsonSerializer
   {
      public void Serialize<T>(T data2Serialize, string path)
      {
         var json = JsonUtility.ToJson(data2Serialize, true);
         File.WriteAllText(path, json);
      }

      public T Deserialize<T>(string path)
      {
         return JsonUtility.FromJson<T>(File.ReadAllText(path));
      }
   }
}