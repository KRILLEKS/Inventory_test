using Infrastructure.Serialization.SerializationInterfaces;

namespace Infrastructure.Serialization.SerializationServices
{
   public interface IJsonSerializer
   {
      public void Serialize<T>(T data2Serialize, string path);
      public T Deserialize<T>(string path);
   }
}