using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    public enum UnregisteredUserType { Undefined, Employee, Customer }
    public class UnregisteredUserProfile
    {
        public int UserId { get; set; } //Generated
        public string UserName { get; set; }//Collected
        public string FirstName { get; set; } //From User table
        public string LastName { get; set; } //From User table
        public string Email { get; set; } //Collected
        public UnregisteredUserType UserType { get; set; }

    }
}
