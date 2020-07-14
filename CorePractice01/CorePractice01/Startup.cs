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
            // ���UMVC�A��
            services.AddControllersWithViews();
            // �C��IClock����n��@�A�|��^TW_Clock����
            services.AddSingleton<IClock, TW_Clock>();
            // IOC�������A����
            // services.AddSingleton<IClock, UTC_Clock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // pipeline���ҨϥΪ��U�A�ȳQ�٤���Middleware�A�䤺�A�ȸ��J���檺���ǬO���N�q��
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �ˬd�O�_�O�}�o�Ҧ��A�Y�O�A�X�{���~�T���|��ܨ�Y�ӳ�W�����W
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // MVC���`���ӷ|�ϥΨ�Html, CSS, JQuery���R�A���
            app.UseStaticFiles();

            // �j���নhttps
            app.UseHttpsRedirection();

            // ��b���ѫe�O�]���Q�b���J�᭱������ƫe��������������
            app.UseAuthentication();

            // ����
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=Index}/{id?}");

                // �Y�n�bcontroller��Attribute���覡�]�w�A�N�i�H�u�g�H�U
                // endpoints.MapControllers();
            });
        }
    }
}
