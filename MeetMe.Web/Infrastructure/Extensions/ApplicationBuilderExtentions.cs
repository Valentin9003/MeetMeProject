using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MeetMe.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;


namespace MeetMe.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtentions
    {

        //Databese Migration
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MeetMeDbContext>().Database.Migrate();



            }

            return app;
        }

        // Add Users
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var db = serviceScope.ServiceProvider.GetRequiredService<MeetMeDbContext>();

                var uploadedUsersIds = new List<string>();


                for (int i = 0; i < 20; i++)
                {


                    var currentEmail = $"valentin_{i}@abv.bg";
                    var currentPassword = $"valentin_{i}@abv.bg";
                    Task<User> user = userManager.FindByEmailAsync(currentEmail);
                    user.Wait();
                    if (user.Result == null)
                    {
                        var currentUserNumber = i;
                        var currentUserEmail = currentEmail;
                       
                        var currentUserIdGuid = Guid.NewGuid().ToString();

                        User currentUser = new User()
                        {
                            Id = currentUserIdGuid,
                            Email = currentEmail,
                            UserName = currentPassword,
                            Pictures = GetPhotos(),
                            Friends = AddFriends(currentUserIdGuid, uploadedUsersIds),
                           
                        };
                       
                        currentUser.Pictures[i].IsProfilePicture = true;

                        Task<IdentityResult> createUser = userManager.CreateAsync(currentUser, currentPassword);

                        createUser.Wait();

                        uploadedUsersIds.Add(currentUserIdGuid);
                    }

                }


            }
            return app;

        }


        // Add friendships between users
        private static List<Friends> AddFriends( string currentUserId, List<string> ids)
        {

            var friendsResultList = new List<Friends>();

           

            for (int i = 0; i < ids.Count(); i++)
            {
               
               
                Friends friend = new Friends()
                {
                    UserId = currentUserId,
                    ContactId = ids[i],
                    IsAccepted = true,



                };
                friendsResultList.Add(friend);
                
            }



            return friendsResultList;
        }

        //get and add picture in list
        private static List<Picture> GetPhotos()
        {

            List<Picture> pictures = new List<Picture>();
            for (int i = 1; i < 21; i++)
            {
                var filePath = Path.GetFullPath($"wwwroot\\images\\profile\\{i}.png");


                byte[] arr = new byte[10 * 1024 * 1024];

                var file = File.ReadAllBytesAsync(filePath)
                    .GetAwaiter()
                    .GetResult();

                using (MemoryStream reader = new MemoryStream(file))
                {
                    arr = reader.ToArray();
                }
                pictures.Add(new Picture
                {
                    PictureId = Guid.NewGuid().ToString(),
                    PictureByteArray = arr,
                    Description = $"Description_{i.ToString()}",
                });
            }

            return pictures;
        }

        public static IApplicationBuilder AddAdministrator(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                Task<IdentityResult> roleResult;


                //Check that there is an Administrator role and create if not
                Task<bool> hasAdminRole = roleManager.RoleExistsAsync(ProjectConstants.AdministratorRole);
                hasAdminRole.Wait();

                if (!hasAdminRole.Result)
                {
                    roleResult = roleManager.CreateAsync(new IdentityRole(ProjectConstants.AdministratorRole));
                    roleResult.Wait();
                }

                //Check if the admin user exists and create it if not

                Task<User> testUser = userManager.FindByEmailAsync(ProjectConstants.AdministratorEmail);
                testUser.Wait();

                if (testUser.Result == null)
                {
                    User Administrator = new User()
                    {
                        Email = ProjectConstants.AdministratorEmail,
                        UserName = ProjectConstants.AdministratorEmail,
                    };
                    Task<IdentityResult> newUser = userManager.CreateAsync(Administrator, "Administrator123");
                    newUser.Wait();

                    if (newUser.Result.Succeeded)
                    {
                        Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(Administrator, "Administrator");
                        newUserRole.Wait();
                    }


                }


                return app;

            }
        }
    }
}
