using AireSpringTest.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireSpringTest.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=EmployeesAppConnection")
        {

        }

        //Stored procedures are created for Employee operations.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .MapToStoredProcedures();
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
