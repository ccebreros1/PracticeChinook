using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
 
    public class UserProfile
    {
        public int UserId { get; set; } //AspNetUser
        public string UserName { get; set; } //AspNetUser
        public int? EmployeeId { get; set; } //AspNetUser
        public int? CustomerId { get; set; } //AspNetUser
        public string FirstName { get; set; } //Customer Table
        public string LastName { get; set; } //Customer Table
        public string Email { get; set; } //AspNetUser
        public string EmailConfirm { get; set; } //AspNetUser
        public IEnumerable<string> RoleMemberships { get; set; }

    }
}
