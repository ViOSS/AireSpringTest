using AireSpringTest.Core;
using System.Collections.Generic;
using System.Linq;

namespace AireSpringTest.Infrastructure
{
    //This class is to accomplish with repository pattern. It contaings all methods required to 
    //perform CRUD and search operations from WebForm. Repository has been created using 
    //stored procedures in order to perform DB operations.
    public class EmployeeRepository : IEmployeeRepository
    {
        DataContext context = new DataContext();

        public object Employees { get; set; }

        public void Add(Employee e)
        {
            context.Employees.Add(e);
            context.SaveChanges();
        }

        public void Edit(Employee e)
        {
            Employee employee = context.Employees.Find(e.EmployeeID);
            employee.EmployeeFirstName = e.EmployeeFirstName;
            employee.EmployeeLastName = e.EmployeeLastName;
            employee.EmployeePhone = e.EmployeePhone;
            employee.EmployeeZip = e.EmployeeZip;
            employee.HireDate = e.HireDate;
            context.SaveChanges();
        }

        public IEnumerable<Employee> FindEmployees(string employeeLastName, string employeePhone)
        {
            var result = (from r in context.Employees
                          where r.EmployeeLastName.Contains(employeeLastName) ||
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
