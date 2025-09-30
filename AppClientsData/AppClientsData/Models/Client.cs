using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClientsData.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BDay { get; set; }
        public Address address { get; set; }
    }
}
