using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MeetMe.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Facebook;
using MeetMe.Web.Infrastructure.Mapping;
using MeetMe.Web.Infrastructure.Extensions;
using MeetMe.Data;
using MeetMe.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using MeetMe.Services.Implementations;
using MeetMe.Services;


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
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });
            

              services.AddDbContext<MeetMeDbContext>(options =>
                  options.UseSqlServer(
                      Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<User>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }
                )
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<MeetMeDbContext>()
              .AddDefaultTokenProviders();

            

            services.AddAutoMapper();
            services.AddDomainServices();

            services.AddAuthentication();
           /* services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddFacebook(options =>
            {
              options.AppId = "Authentication:Facebook:id";
              options.AppSecret = "Authentication:Facebook:password";
            });*/

            services.AddMvc(
                option => {
                    option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


           
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
           
            app.UseDataBaseMigration();
            serviceProvider.AddAdministrator();
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
            app.UseDatabaseErrorPage(); 
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "Profile",
                   template: "{area:exists}/{controller=ProfileController}/{action=Info}"
                    );
                routes.MapRoute(
                   name: "EditProfilePicture",
                   template: "{area:exists}/{controller=ProfileController}/{action=ProfilePicture}/{page?}"
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
   
}

