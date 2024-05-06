using System;
using System.Collections.Generic;

namespace HomesteadManagerApi.Models
{
    public class Garden
    {
        public string HomesteadID { get; set; }
        public int GardenID { get; set; }
        public string GardenName { get; set; }
        public GardenType GardenType { get; set; }
        public string? Location { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation properties
        public ICollection<Bed> Beds { get; set; } = new List<Bed>();
    }
}
