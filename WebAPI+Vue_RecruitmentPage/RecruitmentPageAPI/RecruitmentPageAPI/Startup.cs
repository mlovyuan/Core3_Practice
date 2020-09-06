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
                // 讓註釋寫上API文件(屬性裡設定也要調整)
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
            // 文件路徑配合 SwaggerDoc 的 name。 "/swagger/{SwaggerDoc name}/swagger.json"，
            // description 用於 Swagger UI 右上角選擇不同版本的 SwaggerDocument 顯示名稱使用。
            app.UseSwaggerUI((c) => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobRecruitment v1"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
