using System;
using Infrastructure.Serialization.SerializationServices;
using Zenject;

namespace Infrastructure.Serialization.SerializationInterfaces
{
   public interface ISavable : IInitializable, IDisposable
   {
      public ISaveLoadService _saveLoadService { get; set; }

      public void Save();
      public void Load();
   }
}