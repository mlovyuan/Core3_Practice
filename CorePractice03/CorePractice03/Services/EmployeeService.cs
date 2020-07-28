using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice03.Models;

namespace CorePractice03.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;
        public EmployeeService()
        {
            _employees = new List<Employee>
            {
                new Employee{Id = 1, DepartmentId = 1, FirstName = "Jennifer", LastName = "Lawrence", Gender = Gender.female},
                new Employee{Id = 2, DepartmentId = 1, FirstName = "Catelen", LastName = "Oliveira", Gender = Gender.female},
                new Employee{Id = 3, DepartmentId = 2, FirstName = "Barry", LastName = "Allen", Gender = Gender.male},
                new Employee{Id = 4, DepartmentId = 2, FirstName = "Dinah", LastName = "Drake", Gender = Gender.female},
                new Employee{Id = 5, DepartmentId = 3, FirstName = "Oliver", LastName = "Queen", Gender = Gender.male},
                new Employee{Id = 6, DepartmentId = 3, FirstName = "Gal", LastName = "Gadot", Gender = Gender.female},
            };
        }
        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId));
        }
    }
}
