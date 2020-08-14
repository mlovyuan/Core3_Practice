using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice03.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CorePractice03.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        [BindProperty]
        public Models.Department Department { get; set; }
        
        // �w�]����L�����ϥθ���ܦ�������
        //public void OnGet()
        //{
        //}

        public AddDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _departmentService.Add(Department);
            return RedirectToPage("/Index");
        }
    }
}
