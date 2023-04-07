namespace Infrastructure.StaticData.Enums.InventoryItems
{
   // I won't divide this into different classes
   // In my opinion it's not nice to have a class with only one enum and nothing else
   // Also it's convenient to have all item type enums in one place
   public sealed record ItemEnums
   {
      public enum AmmoTypes
      {
         PistolBullet,
         RifleBullet,
      }
      
      public enum HeadArmourTypes
      {
         Cap,
         Helmet,
      }
      
      public enum BodyArmourTypes
      {
         Jacket,
         BulletproofVest,
      }
   }
}