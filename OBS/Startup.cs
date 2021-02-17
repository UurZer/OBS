using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OBS.Business.LessonForStudentManager;
using OBS.Business.LessonManager;
using OBS.Business.LoginManager;
using OBS.Business.StudentExamGradeManager;
using OBS.Business.StudentManager;
using OBS.Business.TeacherManager;
using OBS.DAL.Orm.EFCore;
using OBS.Entities.Tables;

namespace OBS
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
            services.AddControllersWithViews();
            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);// Hata Alýrsak Bura Olabilir
            services.AddDbContext<ObsContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ObsDB")));
            services.AddScoped(typeof(IObsRepository<>), typeof(ObsRepository<>));
            
            //Dependency Injection
            services.AddScoped<IStudentManager, StudentManager>();
            services.AddScoped<ITeacherManager, TeacherManager>();
            services.AddScoped<ILessonManager, LessonManager>();
            services.AddScoped<ILessonForStudentManager, LessonForStudentManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IStudentExamGradeManager, StudentExamGradeManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
