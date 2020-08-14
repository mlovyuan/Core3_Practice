using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice03.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CorePractice03.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public Models.Employee Employee { get; set; }
        
        // 預設給其他頁面使用跳轉至此頁面的
        //public void OnGet()
        //{
        //}

        public AddEmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> OnPostAsync(int departmentId)
        {
            Employee.DepartmentId = departmentId;

            if (ModelState.IsValid)
            {
                await _employeeService.Add(Employee);
                return RedirectToPage("EmployeeList", new { departmentId });
            }
            return Page();
        }
    }
}
