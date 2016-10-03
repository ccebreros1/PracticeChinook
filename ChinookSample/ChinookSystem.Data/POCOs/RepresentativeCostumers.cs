using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//No annotation since it is not mappped to the DB
namespace ChinookSystem.Data.POCOs
{
    public class RepresentativeCostumers
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
