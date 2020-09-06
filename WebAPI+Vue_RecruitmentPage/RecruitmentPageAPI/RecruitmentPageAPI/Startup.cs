using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace RecruitmentPageAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JobRecruitment",
                    Version = "v1"
                });
                // �������g�WAPI���(�ݩʸ̳]�w�]�n�վ�)
                var xmlPath = AppDomain.CurrentDomain.BaseDirectory + "RecruitmentPageAPI.xml";
                c.IncludeXmlComments(xmlPath);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            // �����|�t�X SwaggerDoc �� name�C "/swagger/{SwaggerDoc name}/swagger.json"�A
            // description �Ω� Swagger UI �k�W����ܤ��P������ SwaggerDocument ��ܦW�٨ϥΡC
            app.UseSwaggerUI((c) => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobRecruitment v1"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
