using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeHapi.Web.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Category { get; set; }
        public string PhysicalAddress { get; set; }
        public string LocationPath { get; set; }
    }
}
