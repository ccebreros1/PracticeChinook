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
using ChinookSystem.Data.Entities; //Entity classes

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
                                            where !registeredEmployees.Any(eid => emp.EmployeeId == eid)
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
                                            where !registeredCustomers.Any(cid => costumer.CustomerId == cid)
                                            select new UnregisteredUserProfile
                                            {
                                                CustomerEmployeeId = costumer.CustomerId,
                                                FirstName = costumer.FirstName,
                                                LastName = costumer.LastName,
                                                UserType = UnregisteredUserType.Customer
                                            }).ToList();
                return unregisteredEmployees.Union(unregisteredCustomers).ToList();
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
                        newuseraccount.CustomerId = userInfo.CustomerEmployeeId;
                        break;
                    }
                case UnregisteredUserType.Employee:
                    {
                        newuseraccount.EmployeeId = userInfo.CustomerEmployeeId;
                        break;
                    }
            }

            //Create the actual AspNetUser record
            this.Create(newuseraccount, STR_DEFAULT_PASSWORD); //Can generate a random password

            //Assign user to an appropiate role
            //Uses the guid like user Id from the User's table
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

        //List all current users
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<UserProfile> ListAllUsers()
        {
            //We will be using the RoleManager to get roles
            var rm = new RoleManager();

            //get the current users off the User security table
            var results = from person in Users.ToList()
                          select new UserProfile
                          {
                              UserId = person.Id,
                              UserName = person.UserName,
                              Email = person.Email,
                              EmailConfirmed = person.EmailConfirmed,
                              RoleMemberships = person.Roles.Select(r => rm.FindById(r.RoleId).Name)
                          };

            //Usomg our own data tables gather the user FirstName and LastName
            using (var context = new ChinookContext())
            {
                Employee eTemp;
                Customer cTemp;

                foreach (var person in results)
                {
                    if (person.EmployeeId.HasValue)
                    {
                        eTemp = context.Employees.Find(person.EmployeeId);
                        person.FirstName = eTemp.FirstName;
                        person.LastName = eTemp.LastName;
                    }
                    else if (person.CustomerId.HasValue)
                    {
                        cTemp = context.Customers.Find(person.CustomerId);
                        person.FirstName = cTemp.FirstName;
                        person.LastName = cTemp.LastName;
                    }
                    else
                    {
                        person.FirstName = "unknown";
                        person.LastName = " ";
                    }
                }
            }

            return results.ToList();
        }

        //add a user to the User table (ListView)
        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public void AddUser(UserProfile userInfo)
        {
            //Create an instance representing the new user
            var useraccount = new ApplicationUser()
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email
            };

            //Create the new user on the physical users table
            this.Create(useraccount, STR_DEFAULT_PASSWORD);

            //Create the UserRoles which were chosen at insert time
            foreach(var roleName in userInfo.RoleMemberships)
            {
                this.AddToRole(useraccount.Id, roleName);
            }
        }
        //delete a user from the user table (ListView)
        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public void RemoveUser(UserProfile userInfo)
        {
            //Business rule:
            //the webmaster cannot be deleted

            //Realize that the only information you have at this time is the DataKeyNames value which is the User ID 
            //(on the User security table the field is ID)

            //obtain the username from the security user table using the User ID value

            string UserName = this.Users.Where(u => u.Id == userInfo.UserId).Select(u => u.UserName).SingleOrDefault().ToString(); //.SingleOrDefault is to make sure the record exists
            if(UserName.Equals(STR_WEBMASTER_USERNAME))
            {
                throw new Exception("The webmaster account cannot be removed");
            }
            else
            {
                this.Delete(this.FindById(userInfo.UserId));
            }
        }
    }//EOC
}//EON
