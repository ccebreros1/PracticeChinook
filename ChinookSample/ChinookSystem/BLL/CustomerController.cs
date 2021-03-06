﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces

using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;

#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class CustomerController
    {
        //Report a dataset containing data from multiple entities
        //this will use Linq to Entity access.
        //POCO classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<RepresentativeCostumers> RepresentativeCostumers_Get(int employeeId)
        {
            //Setup transaction area
            using (var context = new ChinookContext()) //Goes to the appropiate context class
            {
                //Gets the data using the Linq query
                //When you bring your query from Linqpad to your program you must change your reference(s) to the data source
                //You may also need to change your navigation referencing use in Linqpad
                //to the navigation properties you stated in the Entity class definitions
                var results = from x in context.Customers
                              where x.SupportRepId == employeeId
                              orderby x.LastName, x.FirstName
                              select new RepresentativeCostumers
                              {
                                  Name = x.LastName + ", " + x.FirstName,
                                  City = x.City,
                                  State = x.State,
                                  Phone = x.Phone,
                                  Email = x.Email
                              };

                //The following requires the query data in memory
                //.ToList()
                //At this point the query will actually execute
                return results.ToList();
            }
        }
    }
}
