using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClientsData.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Build { get; set; }
        public int? Flat { get; set; }
    }
}
