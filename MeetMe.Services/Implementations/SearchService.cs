using MeetMe.Data;
using MeetMe.Data.Models.Enums;
using MeetMe.Services.Models.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Services.Implementations
{
    public class SearchService : ISearchService
    {

        private readonly MeetMeDbContext db;
        public SearchService(MeetMeDbContext db)
        {
            this.db = db;
        }

        public async Task<int> SearchByCriteriaMaxPageSizeAsync(Sex sex, Country country, City city, LookingFor lookingFor, EyeColor eyes, string currentUserId)
        {



            var maxPageSize = await db.Users

                  .Where(u => u.Sex ==  sex && u.Country == country && u.City == city
                  && u.LookingFor == lookingFor
                  && u.EyeColor == eyes && u.Id != currentUserId).CountAsync();

            return maxPageSize % ServicesDataConstraints.SearchServicePageSize == 0 ?
            maxPageSize / ServicesDataConstraints.SearchServicePageSize :
               (maxPageSize / ServicesDataConstraints.SearchServicePageSize) + 1;
        }



        public async Task<List<SearchServiceModel>> SearchByCriteriaAsync(Sex sex, Country country, City city, LookingFor lookingFor, EyeColor eyes, string currentUserId, int page)
        {
            
            var users = await db.Users.Where( u => u.Sex == sex && u.Country == country && u.City == city
                  && u.LookingFor == lookingFor
                  && u.EyeColor == eyes && u.Id != currentUserId)
            .Include(p => p.Pictures)
            .Skip(ServicesDataConstraints.SearchByCriteriaPageSize * (page - 1))
            .Take(ServicesDataConstraints.SearchByCriteriaPageSize)
            .Select(m => new SearchServiceModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PrifilePicture = m.Pictures
                .Where(p => p.IsProfilePicture == true)
                .Select(l => l.PictureByteArray)
                .FirstOrDefault()

            })
            .ToListAsync();


            return users;
        }

        public async  Task<List<SearchServiceModel>> SearchByNameAsync(string FirstName, string LastName, string CurrentUserId, int Page)
        {
           var users = await db.Users.AsNoTracking()
            .Where(u =>
            ((FirstName == "" || FirstName == null) ? true : u.FirstName.Contains(FirstName)) &&
            ((LastName == "" || LastName == null) ? true : u.LastName.Contains(LastName)) && u.Id != CurrentUserId)
            .Skip((Page - 1) * ServicesDataConstraints.SearchByNamePageSize)
            .Take(ServicesDataConstraints.SearchByNamePageSize)
            .Include(pic=>pic.Pictures)
            .Select(u => new SearchServiceModel
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id,
                PrifilePicture = u.Pictures
                .Where(p => p.IsProfilePicture == true)
                .Select(pp => pp.PictureByteArray)
                .FirstOrDefault()
            }).ToListAsync();
            var usersh = await db.Users.AsNoTracking()
          .Where(u => u.FirstName.Contains(FirstName)).ToListAsync();

            return users;
        }

        public async Task<int> SearchByNameMaxPageSizeAsync(string FirstName, string LastName, string currentUserId)
        {
            var  CountOfUsers = await db.Users.Where(u =>
            ((FirstName == "" || FirstName == null) ? true : u.FirstName.Contains(FirstName)) &&
            ((LastName == "" || LastName == null) ? true : u.LastName.Contains(LastName)) && u.Id != currentUserId)
             .CountAsync(); 

            return CountOfUsers % ServicesDataConstraints.SearchByNamePageSize == 0 ?
                CountOfUsers / ServicesDataConstraints.FriendsServicePageSize :
                (CountOfUsers / ServicesDataConstraints.FriendsServicePageSize) + 1;
        }

        public async Task<int> SearchByUserNameMaxPageSizeAsync(string UserName, string CurrentUserId)
        {
           //TODO: RIGHT NAMING
            var CountOfUsers = await db
                .Users
               .AsNoTracking()
                .Where(u => u.UserName.Contains(UserName) && u.Id != CurrentUserId)
                .CountAsync();

            return CountOfUsers % ServicesDataConstraints.SearchByUserNamePageSize == 0 ?
                CountOfUsers / ServicesDataConstraints.SearchByUserNamePageSize :
                (CountOfUsers / ServicesDataConstraints.SearchByUserNamePageSize) + 1;
        }

        public async Task<List<SearchServiceModel>> SearchByUserNameAsync(string UserName, string CurrentUserId, int Page)
        {
            var UsersByUserNames = await db
               .Users
               .AsNoTracking()
                .Where(u => u.UserName.Contains(UserName) && u.Id != CurrentUserId)
               .Skip((Page -1) * ServicesDataConstraints.SearchByUserNamePageSize)
               .Take(ServicesDataConstraints.SearchByUserNamePageSize)
               .Select(u => new SearchServiceModel
               {
                   Id = u.Id,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   PrifilePicture = u.Pictures
                   .Where(p=> p.IsProfilePicture == true)
                   .Select(pp=>pp.PictureByteArray)
                   .FirstOrDefault()

               }).ToListAsync();
            return UsersByUserNames;
        }

        public async Task<List<SearchServiceModel>> AllAsync(string UserId, int Page)
        {
            var users = await db
                .Users
                .Where(i=> i.Id != UserId)
                .Skip((Page - 1) * ServicesDataConstraints.AllUserPageSize)
                .Take(ServicesDataConstraints.AllUserPageSize)
                .Select(u => new SearchServiceModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PrifilePicture = u.Pictures
                .Where(pp => pp.IsProfilePicture == true)
                .Select(p => p.PictureByteArray)
                .FirstOrDefault()
                }).ToListAsync();

            return users;
        }

        public async Task<int> AllMaxPageAsync()
        {
            var CountOfUsers = await db.Users.CountAsync()-1;

            return CountOfUsers % ServicesDataConstraints.AllUserPageSize == 0 ?
                CountOfUsers / ServicesDataConstraints.AllUserPageSize :
                (CountOfUsers / ServicesDataConstraints.AllUserPageSize) + 1;
        }
    }
}
