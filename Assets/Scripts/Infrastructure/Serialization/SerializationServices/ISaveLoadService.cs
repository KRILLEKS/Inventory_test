using Infrastructure.Serialization.SerializationInterfaces;

namespace Infrastructure.Serialization.SerializationServices
{
   public interface ISaveLoadService
   {
      public void Write<T>(string pathPiece, T objectToWrite) where T : ISavableData;
      public T Read<T>(string pathPiece) where T : ISavableData;
   }
}