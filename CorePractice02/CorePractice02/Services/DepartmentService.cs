using CorePractice02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice02.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly List<Department> _departments;

        public DepartmentService()
        {
            _departments = new List<Department>()
            {
                new Department() { Id = 1, Name = "HR", Location ="ShangHai", EmployeeCount = 16 },
                new Department() { Id = 2, Name = "R&D", Location = "ShangHai", EmployeeCount = 52 },
                new Department() { Id = 3, Name = "Sales", Location = "ShangHai", EmployeeCount = 200 },
            };
        }
        
        // 添加部門
        public Task Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            // return Task.Run(() => _departments.AsEnumerable());
            // 委派
            return Task.Run(function:() => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.FirstOrDefault((x) => x.Id == id));
        }

        // 獲得公司總體情況
        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                return new CompanySummary
                {
                    // 員工數量
                    EmployeeCount = _departments.Sum((x) => x.EmployeeCount),
                    // 部門平均員工數量
                    AverageDepartmentEmployeeCount = (int)_departments.Average((x) => x.EmployeeCount)
                };
            });
        }
    }
}
