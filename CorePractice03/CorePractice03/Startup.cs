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
            // �C��IClock����n��@�A�|��^TW_Clock����
            services.AddSingleton<IClock, TW_Clock>();
            // IOC�������A����
            // services.AddSingleton<IClock, UTC_Clock>();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            // �z�L�̩ۨʪ`�J���覡���o appSettings.json(�պA�]�w��) ��"ThisProjectTest"���]�w��
            // �i�bController�����IOptions�Ӫ`�J�ϥ�
            // �bRazor page�ϥΫh�� @inject IOptions<ThisProjectTestOptions> + �ܼƦW��
            services.Configure<ThisProjectTestOptions>(_configuration.GetSection(key: "ThisProjectTest"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �ˬd�O�_�O�}�o�Ҧ��A�Y�O�A�X�{���~�T���|��ܨ�Y�ӳ�W�����W
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // MVC���`���ӷ|�ϥΨ�Html, CSS, JQuery���R�A���A�ɮ׷|��bwwwroot
            app.UseStaticFiles();

            // �j���নhttps
            app.UseHttpsRedirection();

            // ��b���ѫe�O�]���Q�b���J�᭱������ƫe��������������
            app.UseAuthentication();

            // ����
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // �]���O�� RazorPages
                endpoints.MapRazorPages();
            });
        }
    }
}
