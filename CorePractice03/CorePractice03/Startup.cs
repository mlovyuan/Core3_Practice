using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice03.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CorePractice03
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuaration)
        {
            _configuration = configuaration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            // 每當有IClock物件要實作，會返回TW_Clock物件
            services.AddSingleton<IClock, TW_Clock>();
            // IOC控制反轉，解藕
            // services.AddSingleton<IClock, UTC_Clock>();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            // 透過相依性注入的方式取得 appSettings.json(組態設定檔) 裡"ThisProjectTest"的設定值
            // 可在Controller那邊用IOptions來注入使用
            // 在Razor page使用則為 @inject IOptions<ThisProjectTestOptions> + 變數名稱
            services.Configure<ThisProjectTestOptions>(_configuration.GetSection(key: "ThisProjectTest"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 檢查是否是開發模式，若是，出現錯誤訊息會顯示到某個單獨頁面上
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // MVC正常應該會使用到Html, CSS, JQuery等靜態文件，檔案會放在wwwroot
            app.UseStaticFiles();

            // 強制轉成https
            app.UseHttpsRedirection();

            // 放在路由前是因為想在載入後面頁面資料前先做身分的驗證
            app.UseAuthentication();

            // 路由
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // 因為是用 RazorPages
                endpoints.MapRazorPages();
            });
        }
    }
}
