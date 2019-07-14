using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireSpringTest.Core
{
    public interface IEmployeeRepository
    {
        void Add(Employee e);
        void Edit(Employee e);
        void Remove(int Id);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> FindEmployees(string employeeLastName, string employeePhone);
    }
}