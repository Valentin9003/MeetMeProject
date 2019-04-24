using MeetMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Infrastructure.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider AddAdministrator(this IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            Task<IdentityResult> roleResult;
            //string email = "Administrator@abv.bg";

            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync(ProjectConstants.AdministratorRole);
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole(ProjectConstants.AdministratorRole));
                roleResult.Wait();
            }

            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<User> testUser = userManager.FindByEmailAsync(ProjectConstants.AdministratorEmail);
            testUser.Wait();

            if (testUser.Result == null)
            {
                User Administrator = new User();
                Administrator.Email = ProjectConstants.AdministratorEmail;
                Administrator.UserName = ProjectConstants.AdministratorEmail;

                Task<IdentityResult> newUser = userManager.CreateAsync(Administrator, "Administrator123");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(Administrator, "Administrator");
                    newUserRole.Wait();
                }


            }
            return serviceProvider;
        }

    }
}
