using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces

using Microsoft.AspNet.Identity.EntityFramework; //For UserStore
using Microsoft.AspNet.Identity; //For UserManager
using System.ComponentModel; //ODS
using System.ComponentModel.DataAnnotations;
using ChinookSystem.DAL; //Context class

#endregion

namespace ChinookSystem.Security
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }

        //Setting up the default webMaster

        #region Constants
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        private const string STR_EMAIL_FORMAT = "{0}@Chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion

        public void AddWebMaster()
        {
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                //this Create command is from the inherited user manager class
                //this command creates a record on the security Users table (AspNetUsers)
                this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);
                //this AddToRole command is from the inherited UserManager class
                //this command creates a record on the security UserRole table (AspNetRoles)
                this.AddToRole(webMasterAccount.Id, SecurityRoles.WebsiteAdmins);
            }
        }//eom

        //Create the CRUD methods for adding a user to the security User table
        //Read of data to display on gridview

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<UnregisteredUserProfile> ListAllUnRegisteredUsers()
        {
            using (var context = new ChinookContext())
            {
                //The data needs to be in memory for execution by the next query
                //to complish this use .ToList() which will force the query to execute
            
                //List() set containing the list of employeeids
                var registeredEmployees = (from emp in Users
                                          where emp.EmployeeId.HasValue
                                          select emp.EmployeeId).ToList();

                //Compare the IEnumerable set to the user data table Employees
                var unregisteredEmployees = (from emp in context.Employees
                                            where registeredEmployees.Any(eid => emp.EmployeeId == eid)
                                            select new UnregisteredUserProfile
                                            {
                                                CustomerEmployeeId = emp.EmployeeId,
                                                FirstName = emp.FirstName,
                                                LastName = emp.LastName,
                                                UserType = UnregisteredUserType.Employee
                                            }).ToList();
                //IEnumerable set containing the list of customerids
                var registeredCustomers = (from costumer in Users
                                          where costumer.CustomerId.HasValue
                                          select costumer.EmployeeId).ToList();

                //Compare the IEnumerable set to the user data table Customers
                var unregisteredCustomers = (from costumer in context.Customers
                                            where registeredCustomers.Any(cid => costumer.CustomerId == cid)
                                            select new UnregisteredUserProfile
                                            {
                                                CustomerEmployeeId = costumer.CustomerId,
                                                FirstName = costumer.FirstName,
                                                LastName = costumer.LastName,
                                                UserType = UnregisteredUserType.Customer
                                            }).ToList();
                return unregisteredEmployees.Union(unregisteredEmployees).ToList();
            }
        }//eom

        //Register a user to the user table (gridView)
        public void RegisteredUser(UnregisteredUserProfile userInfo)
        {
            //basic information needed for the security user record 
            //password, email, username
            //you could randomly generate a password we will use the deffault password
            //The instance of the required user is based on our ApplicationUser
            var newuseraccount = new ApplicationUser()
            {
                UserName = userInfo.AssignedUserName,
                Email = userInfo.AssignedEmail
            };

            //Set the customerID or EamployeeID
            switch (userInfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    {
                        newuseraccount.Id = userInfo.CustomerEmployeeId.ToString();
                        break;
                    }
                case UnregisteredUserType.Employee:
                    {
                        newuseraccount.Id = userInfo.CustomerEmployeeId.ToString();
                        break;
                    }
            }

            //Create the actual AspNetUser record
            this.Create(newuseraccount, STR_DEFAULT_PASSWORD); //Can generate a random password

            //Assign user to an appropiate role
            switch (userInfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.RegisteredUsers);
                        break;
                    }
                case UnregisteredUserType.Employee:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.Staff);
                        break;
                    }
            }
        }//eom

        //add a user to the User table (ListView)

        //delete a user from the user table (ListView)
    }//EOC
}//EON
