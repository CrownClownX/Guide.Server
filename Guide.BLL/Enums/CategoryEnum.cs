using Guide.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Enums
{
    public enum CategoryEnum
    {
        [Shortcut("catdanger")]
        DANGEROUS,
        [Shortcut("catsafe")]
        SAFE,
        [Shortcut("catinfo")]
        INFORMATION
    }
}
