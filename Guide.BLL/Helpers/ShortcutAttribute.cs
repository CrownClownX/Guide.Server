using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Helpers
{
    public class ShortcutAttribute : Attribute
    {
        public string Shortcut { get; protected set; }

        public ShortcutAttribute(string shortcut)
        {
            Shortcut = shortcut;
        }

    }
}
