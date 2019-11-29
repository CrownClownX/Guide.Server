using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Shortcut { get; set; }
        public string Name { get; set; }

        public List<Marker> Markers { get; set; }
    }
}
