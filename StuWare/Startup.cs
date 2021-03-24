using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StuWare.Data;
using StuWare.Data.Repository;
using System.Configuration;

namespace StuWare
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
            services.AddDbContext<StuWareContext>(option => option.UseLazyLoadingProxies()
            .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = StuWareDB; Trusted_Connection = True;MultipleActiveResultSets = True"));
         
            services.AddControllers(options => options.EnableEndpointRouting = false);

            services.AddTransient<IStudentLessonRepository, StudentLessonRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IStudentLessonGradeRepository, StudentLessonGradeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPanelRepository, PanelRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Index}/{id?}");
            });

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 401)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/UnAuthAccess";
                        await next();
                    });
                }
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/NotFound";
                        await next();
                    });
                }
                if (context.HttpContext.Response.StatusCode == 500)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/UnExpected";
                        await next();
                    });
                }
            });
        }
    }
}
