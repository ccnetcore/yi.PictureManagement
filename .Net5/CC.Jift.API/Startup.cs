using CC.Jift.BLL;
using CC.Jift.EFDAL;
using CC.Jift.IBLL;
using CC.Jift.IDAL;
using CC.Jift.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CC.Jift.API", Version = "v1" });
            });
            //string connection = Configuration["ConnectionStrings"];
            //services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseSqlServer(connection);//设置运行分页

            //});
            string connection = Configuration["ConnectionStringsForMySQL"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(connection);
              
            });

            services.AddScoped(typeof(IBaseDal<>),typeof(BaseDal<>));
      
            //services.AddScoped(typeof(BaseBll<>));
            services.AddScoped<IStudentBll, StudentBll>();
            services.AddScoped<IAdminBll, AdminBll>();
            services.AddScoped<IMailBll, MailBll>();
            services.AddScoped<IMyClassBll, MyClassBll>();
            services.AddScoped<IMyFileBll, MyFileBll>();
            services.AddScoped<INoteBll, NoteBll>();
            services.AddScoped<ICommentBll, CommentBll>();
        
            services.AddScoped<IStudentAddOrDel, StudentAddOrDel>();
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod()
                       .SetIsOriginAllowed(_ => true)
                       .AllowAnyHeader()
                       .AllowCredentials();
               }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CC.Jift.API v1"));
            }
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseRouting();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
