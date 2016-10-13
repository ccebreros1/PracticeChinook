﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces

using Microsoft.AspNet.Identity.EntityFramework; //For UserStore
using Microsoft.AspNet.Identity; //For UserManager

#endregion

namespace ChinookSystem.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }
}
