using AutoMapper;
using MeetMe.Data;
using MeetMe.Data.Models;
using MeetMe.Data.Models.Enums;
using MeetMe.Web.Hubs;
using MeetMe.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SignalR;

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

            services.AddDefaultIdentity<User>(options =>
            {

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
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
                options.AppId = "2617203478350569";
                options.AppSecret = "24843157ec3dc2dcfe9219c8f8525ed0";
            });

            services.AddRazorPages();

            services.AddAuthentication();

            services.AddMvc()
                 .AddRazorPagesOptions(options =>
                 {
                     options.Conventions.AuthorizePage("/chat");
                 });

            services.AddDomainServices();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // app.UseDataBaseMigration(); TODO: Needed Changes

            app.Seed(); // Add Users and Pictures in DataBase

            app.AddAdministrator();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();

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

            app.UseCors();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");

                endpoints.MapControllerRoute(
                name: "profile",
                pattern: "{area:exists}/{controller=profilecontroller}/{action=info}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });
        }
    }
}
