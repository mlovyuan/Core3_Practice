using CorePractice01.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice01.Controllers
{
    public class HomeController:Controller
    {
        // 因為Startup.cs的DI註冊設定，會使用TW_Clock注入
        public HomeController(IClock clock)
        {

        }
    }
}
