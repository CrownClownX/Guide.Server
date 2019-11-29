using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Guide.BLL.Helpers
{
    public static class EnumHelper
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            ShortcutAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(ShortcutAttribute), false) as ShortcutAttribute[];

            return attribs.Length > 0 ? attribs[0].Shortcut : "";
        }
    }
}
