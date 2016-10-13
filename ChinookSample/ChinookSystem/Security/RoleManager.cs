using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using Microsoft.AspNet.Identity; //RoleManager
using Microsoft.AspNet.Identity.EntityFramework; //IdentityRole and RoleStore

#endregion

namespace ChinookSystem.Security
{
    public class RoleManager : RoleManager<IdentityRole>
    {
        public RoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {
          
        }

        //This method will be executed when the application starts up under IIS (Internet Information Services)
        public void AddStartupRoles()
        {
            foreach(string roleName in SecurityRoles.StarupSecurityRoles)
            {
                //Check if the role already exists in the security tables located in the database, if not create it
                if(!Roles.Any(r => r.Name.Equals(roleName)))
                {
                    this.Create(new IdentityRole(roleName));
                }
            }
        }
    }
}
