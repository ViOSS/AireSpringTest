using AireSpringTest.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireSpringTest.Infrastructure
{
    public class EmployeeInitializeDB : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Employees.Add(
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeFirstName = "Daniel",
                    EmployeeLastName = "Smith",
                    EmployeePhone = "(503) 222-2222",
                    EmployeeZip = "12535",
                    HireDate = DateTime.Parse("06/06/2013")
                });

            context.SaveChanges();

            base.Seed(context); 
        }
    }
}
