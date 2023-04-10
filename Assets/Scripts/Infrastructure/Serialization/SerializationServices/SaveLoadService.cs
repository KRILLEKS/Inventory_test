using System;
using System.IO;
using Infrastructure.Serialization.SerializationInterfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure.Serialization.SerializationServices
{
   public class SaveLoadService : ISaveLoadService
   {
      private IJsonSerializer _jsonSerializer;

      public SaveLoadService(IJsonSerializer jsonSerializer)
      {
         _jsonSerializer = jsonSerializer;
      }

      public void Write<T>(string pathPiece, T objectToWrite) where T : ISavableData
      {
         _jsonSerializer.Serialize(objectToWrite, Path.Combine(Application.persistentDataPath, pathPiece));
      }

      public T Read<T>(string pathPiece) where T : ISavableData
      {
         if (File.Exists(Path.Combine(Application.persistentDataPath, pathPiece)) == false)
            return default;

         return _jsonSerializer.Deserialize<T>(Path.Combine(Application.persistentDataPath, pathPiece));
      }
   }
}