using CorePractice02.Models;
using CorePractice02.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice02.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.title = "Department Index";
            var depaetments = _departmentService.GetAll();
            return View(await depaetments);
        }

        // 要增加部門的頁面
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.titlw = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }
            // 用nameof是因為在重構或重新命名名稱時會自己更改相依的地方
            return RedirectToAction(nameof(Index));
        }
    }
}
