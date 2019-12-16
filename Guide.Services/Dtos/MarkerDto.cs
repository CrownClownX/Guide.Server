using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.Services.Dtos
{
    public class MarkerDto
    {
        public long Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string Shortcut { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
