using MeetMe.Data.Models.Enums;
using MeetMe.Services.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetMe.Services
{
    public interface ISearchService
    {
        Task<List<SearchServiceModel>> SearchByCriteriaAsync( Sex sex, Country country, City city, LookingFor lookingFor, EyeColor eyes,  string currentUserId, int page);
        Task<int> SearchByCriteriaMaxPageSizeAsync(Sex sex, Country country, City city, LookingFor lookingFor, EyeColor eyes, string currentUserId);

        Task<List<SearchServiceModel>> SearchByNameAsync(string FirstName, string LastName, string CurrentUser, int Page);

        Task<int> SearchByNameMaxPageSizeAsync(string FirstName, string LastName, string currentUserId);

        Task<int> SearchByUserNameMaxPageSizeAsync(string UserName, string CurrentUserId);
        Task<List<SearchServiceModel>> SearchByUserNameAsync(string UserName, string CurrentUserId, int Page);

        Task<List<SearchServiceModel>> AllAsync(string UserId, int Page);

        Task<int> AllMaxPageAsync();
    }
 
}
