
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Implementation.Utils
{
   class EnumUtils
   {
      public static string GetEnumDescription(Enum value)
      {
         FieldInfo fi = value.GetType().GetField(value.ToString());
         DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

         if (attributes != null && attributes.Length > 0)
         {
            return attributes[0].Description;
         }
         else
         {
            return value.ToString();
         }
      }

      public static Dictionary<string, Enum> GetEnumMapping(Type enumType)
      {
         if (!enumType.IsEnum)
         {
            throw new ArgumentException("Enum type expected");
         }

         Dictionary<string, Enum> dic = new Dictionary<string, Enum>();
         var values = Enum.GetValues(enumType);
         foreach (Enum item in values)
         {
            dic.Add(GetEnumDescription(item), item);
         }

         return dic;
      }
   }
}
