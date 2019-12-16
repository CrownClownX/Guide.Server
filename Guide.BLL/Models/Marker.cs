using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Models
{
    public class Marker
    {
        public long Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
