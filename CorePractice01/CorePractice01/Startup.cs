using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice01.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CorePractice01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 註冊MVC服務
            services.AddControllersWithViews();
            // 每當有IClock物件要實作，會返回TW_Clock物件
            services.AddSingleton<IClock, TW_Clock>();
            // IOC控制反轉，解藕
            // services.AddSingleton<IClock, UTC_Clock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // pipeline內所使用的各服務被稱之為Middleware，其內服務載入執行的順序是有意義的
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 檢查是否是開發模式，若是，出現錯誤訊息會顯示到某個單獨頁面上
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // MVC正常應該會使用到Html, CSS, JQuery等靜態文件
            app.UseStaticFiles();

            // 強制轉成https
            app.UseHttpsRedirection();

            // 放在路由前是因為想在載入後面頁面資料前先做身分的驗證
            app.UseAuthentication();

            // 路由
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=Index}/{id?}");

                // 若要在controller用Attribute的方式設定，就可以只寫以下
                // endpoints.MapControllers();
            });
        }
    }
}
