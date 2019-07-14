using AireSpringTest.Core;
using System.Collections.Generic;
using System.Linq;

namespace AireSpringTest.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DataContext context = new DataContext();
        public void Add(Employee e)
        {
            context.Employees.Add(e);
            context.SaveChanges();
        }

        public void Edit(Employee e)
        {
            context.Entry(e).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Employee> FindEmployees(string employeeLastName, string employeePhone)
        {
            var result = (from r in context.Employees
                          where r.EmployeeLastName.Contains(employeeLastName) &&
                                r.EmployeePhone.Contains(employeePhone)
                          select r);
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public void Remove(int Id)
        {
            Employee e = context.Employees.Find(Id);
            context.Employees.Remove(e);
            context.SaveChanges();
        }
    }
}
