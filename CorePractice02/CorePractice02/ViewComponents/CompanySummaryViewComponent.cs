using CorePractice02.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice02.ViewComponents
{
    public class CompanySummaryViewComponent : ViewComponent
    {
        private readonly IDepartmentService _departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.title = title;
            var summery = await _departmentService.GetCompanySummary();
            return View(summery);
        }
    }
}
