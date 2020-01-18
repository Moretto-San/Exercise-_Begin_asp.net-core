using CodersAcademy.Data;
using CodersAcademy.Middleware;
using CodersAcademy.Models;
using CodersAcademy.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Underwater
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureRepository();

            services.AddDbContext<UnderWaterContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<UserAccount>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<UserDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/UserAccount/Login";
                options.LogoutPath = $"/UserAccount/LoginOut";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.LogRequest();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CodersAcademyRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Fish", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
