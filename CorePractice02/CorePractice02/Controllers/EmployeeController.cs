using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice02.Models;
using CorePractice02.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorePractice02.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);
            ViewBag.title = $"Employees of {department.Name}";

            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);
        }

        public IActionResult Add(int departmentId)
        {
            ViewBag.titlw = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            // 用nameof是因為在重構或重新命名名稱時會自己更改相依的地方
            // 路由參數，因為轉向Index頁面，Index方法有收參數，正常新增完後會想檢查，所以我們將此部門Id當作參數Id傳回
            return RedirectToAction(nameof(Index), routeValues: new { departmentId = model.DepartmentId});
        }
        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), routeValues: new { departmentId = employee.DepartmentId });
        }
    }
}