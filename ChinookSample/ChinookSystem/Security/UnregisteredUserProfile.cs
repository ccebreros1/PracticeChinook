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
        public int CustomerEmployeeId { get; set; } //Generated
        public string AssignedUserName { get; set; }//Collected
        public string FirstName { get; set; } //From User table
        public string LastName { get; set; } //From User table
        public string AssignedEmail { get; set; } //Collected
        public UnregisteredUserType UserType { get; set; }

    }
}
