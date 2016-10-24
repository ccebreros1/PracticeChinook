using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using Microsoft.AspNet.Identity; //RoleManager
using Microsoft.AspNet.Identity.EntityFramework; //IdentityRole and RoleStore
using System.ComponentModel;    //ODS

#endregion

namespace ChinookSystem.Security
{
    [DataObject]
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
        }//eom
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<RoleProfile> ListAllRoles()
        {
            var um = new UserManager();
            //The data from Roles needs to be in memory for use by the query --> Use .ToList()
            var results = from role in Roles.ToList()
                          select new RoleProfile
                          {
                              RoleId = role.Id, //From security table
                              RoleName = role.Name, //Security table
                              UserNames = role.Users.Select(r => um.FindById(r.UserId).UserName)
                          };
            return results.ToList();
        }//eom
        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public void AddRole(RoleProfile role)
        {
            //Any business roles to consider
            //The role should not already exist on the roles table
            if(!this.RoleExists(role.RoleName))
            {
                this.Create(new IdentityRole(role.RoleName));
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void deleteRole(RoleProfile role)
        {
            this.Delete(this.FindById(role.RoleId));
        }//eom

        //This method will profuce a list of all the roles (roleName)
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<string> ListAllRoleNames()
        {
            return this.Roles.Select(r => r.Name).ToList();
        }
    }//eoc
}//eon
