using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MeetMe.Data;
using Microsoft.AspNetCore.Mvc;
using MeetMe.Web.Infrastructure.Extensions;
using MeetMe.Data.Models;
using AutoMapper;
using MeetMe.Web.Infrastructure.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace MeetMe.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });

            services.AddDbContext<MeetMeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => {

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
           } )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MeetMeDbContext>();
            services.AddSignalR();
            services.AddAutoMapper(typeof(Startup));
           
           
            services.AddControllersWithViews(option => option.Filters
               .Add(new AutoValidateAntiforgeryTokenAttribute())
               );
            services.AddAuthentication();
            services.AddAuthentication()
            .AddFacebook(options =>
            {
                options.AppId = "*****************";
                options.AppSecret = "****************************";
            });
            services.AddSignalR();
            services.AddRazorPages();
            services.AddAuthentication();
            services.AddMvc();
            services.AddDomainServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDataBaseMigration();
            app.Seed(); // Add Users and Pictures in DataBase
            app.AddAdministrator();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "Profile",
                pattern: "{area:exists}/{controller=ProfileController}/{action=Info}");

                endpoints.MapControllerRoute(
                  name: "EditProfilePicture",
                  pattern: "{area:exists}/{controller=ProfileController}/{action=ProfilePicture}/{page?}");

                endpoints.MapControllerRoute(
               name: "Search",
               pattern: "{area:exists}/{controller=SearchController}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
                endpoints.MapRazorPages();
            });
        }
    }
}
