using System;
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
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Employee> Employee_ListAll()
        {
            //Setup transaction area
            using (var context = new ChinookContext()) //Goes to the appropiate context class
            {
                //Gets the entire table comming back
                return context.Employees.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeNameList> EmployeeNameList_Get()
        {
            using (var context = new ChinookContext()) //Goes to the appropiate context class
            {
                //Gets the entire table comming back
                var results = from x in context.Employees
                              orderby x.LastName, x.FirstName
                              select new EmployeeNameList
                              {
                                  EmployeeId = x.EmployeeId,
                                  Name = x.FirstName + x.LastName
                              };
                return results.ToList();
            }
        }
    }
}
