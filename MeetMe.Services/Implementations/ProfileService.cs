using MeetMe.Data;
using MeetMe.Data.Models;
using MeetMe.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MeetMe.Data.Models.Enums;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.EntityFrameworkCore;
using MeetMe.Services.Models.Profile.ChildProfilePictureServiceModels;
using MeetMe.Services.Models.Profile;
using System.IO;
using System.Threading;
using Z.EntityFramework.Plus;
using Microsoft.EntityFrameworkCore.Proxies;


namespace MeetMe.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly MeetMeDbContext db;
        public readonly UserManager<User> userManager;
        public readonly IMapper mapper;
       
        public ProfileService(MeetMeDbContext db, UserManager<User> userManager, IMapper mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this.mapper = mapper;
           
        }

      

        public async Task<ProfileInfoServiceModel> GetProfileInformationAsync(string id)
        {
            var user = await db.Users.FindAsync(id);
          
           var userProfilInfo = mapper.Map<ProfileInfoServiceModel>(user);
           
           return userProfilInfo;

         }

        public async Task<bool> SafeProfileInformationAsync(string UserId,string FirstName, string Biography, DateTime BirthDay,
            City City, Country Country, EyeColor EyeColor, double Height,
            int Weight, string LastName, LookingFor LookingFor, Sex Sex)
        {

            if (BirthDay > DateTime.UtcNow)
            {
                return false;
            }
            var user = await db.Users.FindAsync(UserId);
            user.Biography = Biography;
            user.BirthDay = BirthDay;
            user.City = City;
            user.Country = Country;
            user.EyeColor = EyeColor;
            user.FirstName = FirstName;
            user.Height = Height;
            user.LastName = LastName;
            user.Sex = Sex;
            user.Weight = Weight;
            user.LookingFor = LookingFor;

            await db.SaveChangesAsync();
            return true;

        }

        public async Task<ProfilePictureServiceModel> EditProfilePictureAsync(string id, int page)
        {
            var user = await db.Users.FindAsync(id);
            var model = await db.Users.Where(u => u.Id == id).Select(p => new ProfilePictureServiceModel
            {
                Id = p.Pictures
                .Where(pp => pp.isProfilePicture == true)
                .Select(i => i.PictureId).FirstOrDefault(),

                PictureByteArray = p.Pictures
                .Where(pp => pp.isProfilePicture == true)
                .Select(cpp => cpp.PictureByteArray)
                .FirstOrDefault(),

                allPage = (p.Pictures.Count() - 1) % ServicesDataConstraints.EditProfilePictureServicePageSize == 0 ? ((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) : (((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) + 1),//Math.Floor((((decimal)p.Pictures.Count()-1) / ServicesDataConstraints.EditProfilePictureServicePageSize)),

                Pictures = p.Pictures
                .Where(f=> f.isProfilePicture == false)
                .OrderByDescending(o=>o.PictureId)
                .Skip((page - 1) * ServicesDataConstraints.EditProfilePictureServicePageSize)
                .Take(ServicesDataConstraints.EditProfilePictureServicePageSize)
                .Select(k =>
                new ChildPicturesServiceModel
                {
                    PictureByteArray = k.PictureByteArray,
                    Id = k.PictureId,
                   
                })
                .ToList()
            }).FirstOrDefaultAsync();

               return model;
        }

        public async Task<bool> UploadProfilePictureAsync(IFormFile picture, string userId)
        {
           
            byte[] byteArray = new byte[1024 * 1024 * 10];
            if (picture == null)
            {
                return false;
            }
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await picture.CopyToAsync(memoryStream, CancellationToken.None);
              
                byteArray = memoryStream.ToArray();
            }

            if (byteArray == null)
            {
                return false;
            }
            var ProfilePictureExist = await db.Picture
                .Where(k => k.isProfilePicture == true && k.UserId == userId)
                .AnyAsync();
            if (ProfilePictureExist)
            {
                var CurrentProfilePicture = await db
                    .Picture
                    .Where(k => k.isProfilePicture == true && k.UserId == userId)
                    .FirstOrDefaultAsync();

                CurrentProfilePicture.isProfilePicture = false;

                await db.SaveChangesAsync();
            }

            var newPicture = new Picture();
            newPicture.isProfilePicture = true;
            newPicture.PictureByteArray = byteArray;
            newPicture.UserId = userId;
            await db.Picture.AddAsync(newPicture);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChooseProfilePictureAsync(string futurePictureId, string currentPictureId, string userId)
        {
            var currentProfilePictureExist =  await db
                .Picture.Where(p => p.UserId == userId && p.isProfilePicture == true)
                .AnyAsync();
            if (currentProfilePictureExist)
            {
               var currentProfilePicture = await db
                    .Picture
                    .Where(p => p.UserId == userId && p.isProfilePicture == true)
                    .FirstOrDefaultAsync();

                currentProfilePicture.isProfilePicture = false;

                await db.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            if (db.Picture.AnyAsync(p => p.UserId == userId && p.PictureId == futurePictureId).Result)
            {
                var newProfilePicture = await db
                    .Picture.FirstOrDefaultAsync(p => p.UserId == userId && p.PictureId == futurePictureId);

                newProfilePicture.isProfilePicture = true;

                await db.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            return true;
        }

        public async Task<List<FriendsServiceModel>> GetFriendsAsync(string userId, int page)
        {
           
            var friendsList = await db
                 .Friends
                 .Where(u => (u.UserId == userId || u.ContactId == userId) && u.IsAccepted == true)
                 .OrderBy(u => u.UserId)
                 .ThenBy(c => c.ContactId)

            .Select
            (m => new FriendsServiceModel   
            {

                FirstName = (m.ContactId == userId ? m.User.FirstName : m.Contact.FirstName),

                LastName = (m.ContactId == userId ? m.User.LastName : m.Contact.LastName),

                UserId = (m.ContactId == userId ? m.UserId : m.ContactId),

                ProfilePicture = (m.ContactId == userId ? m.User
            .Pictures
            .Where(p => p.isProfilePicture == true)
            .Select(b => b.PictureByteArray)
            .SingleOrDefault() :
             m.Contact.Pictures
            .Where(p => p.isProfilePicture == true)
            .Select(b => b.PictureByteArray)
            .SingleOrDefault())
            })
            .OrderBy(o => o.FirstName)
            .ThenBy(th => th.LastName)
            .Skip((page - 1) * ServicesDataConstraints.FriendsServicePageSize)
            .Take(ServicesDataConstraints.FriendsServicePageSize)
            .ToListAsync();

            return friendsList;

            

            

        }

        public async Task<int> GetFriendsMaxPageSizeAsync(string userId)
        {
            var friendsListCount = await db
                .Friends
                .Where(u => u.UserId == userId || u.ContactId == userId && u.IsAccepted == true)
                .ToAsyncEnumerable().Count();

            return friendsListCount % ServicesDataConstraints.FriendsServicePageSize == 0 ?
                friendsListCount / ServicesDataConstraints.FriendsServicePageSize :
                (friendsListCount % ServicesDataConstraints.FriendsServicePageSize) + 1;

            

        }

        public async Task<bool> DeleteFriendAsync(string userId, string friendId)
        {
            var friendConnectionExist = await db
                .Friends
                .Where(u => (u.ContactId == userId || u.ContactId == friendId) && (u.UserId == userId || u.UserId == friendId) && u.IsAccepted == true)
                .AnyAsync();
            if (friendConnectionExist)
            {
               var checkForDeleted = await db.Friends
               .Where(u => (u.ContactId == userId || u.ContactId == friendId) && (u.UserId == userId || u.UserId == friendId) && u.IsAccepted == true)
                .DeleteAsync();

                if (checkForDeleted == 1)
                {
                    return true;
                }

            }
            return false;
               
        }
    }
}
