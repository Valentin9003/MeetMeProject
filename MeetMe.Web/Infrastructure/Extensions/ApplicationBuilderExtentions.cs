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
                var  userManager =serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var db = serviceScope.ServiceProvider.GetRequiredService<MeetMeDbContext>();
              

                
                
                 for (int i = 0; i < 20; i++)
                {


                    var currentEmail = $"valentin_{i}@abv.bg";
                    var currentPassword = $"valentin_{i}@abv.bg";
                    Task<User> user = userManager.FindByEmailAsync(currentEmail);
                    user.Wait();
                    if (user.Result == null)
                    {
                        
                        User currentUser = new User()
                        {
                            Email = currentEmail,
                            UserName = currentPassword,
                            Pictures = getPhotos(),
                        };

                        currentUser.Pictures[i].isProfilePicture = true;

                        Task<IdentityResult> createUser = userManager.CreateAsync(currentUser, currentPassword);

                        createUser.Wait();
                    }
                  
                }
            

            }
            return app;

        }

        //get and add picture in list
        private static List<Picture> getPhotos()
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
                    PictureByteArray = arr,
                    Description = $"Description_{i.ToString()}",
                });
            }
            
            return pictures;
        }
    }
    
}
