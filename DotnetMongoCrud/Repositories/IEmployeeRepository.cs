using DotnetMongoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMongoCrud.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddEmployee(Employee employee);
        Task<IList<Employee>> EmployeeList();
        Task<Employee> GetEmployee(string id);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(string id);
    }
}
