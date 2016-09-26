using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//No annotations since this is not an entity

namespace ChinookSystem.Data.POCOs
{
    public class CustomerContact
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
