using System;

namespace DerivedClasses
{
   [Serializable]
   public class EnumTypeCompound
   {
      public EnumTypeCompound(int enumRawValue, Type type)
      {
         EnumRawValue = enumRawValue;
         Type = type;
      }
      
      public int EnumRawValue;
      public Type Type;
   }
}