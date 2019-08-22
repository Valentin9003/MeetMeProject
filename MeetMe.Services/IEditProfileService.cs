using MeetMe.Data.Models.Enums;
using MeetMe.Services.Models.EditProfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetMe.Services
{
    public interface IEditProfileService
    {

        Task<ProfileInfoServiceModel> GetProfileInformationAsync(string id);

        Task<bool> SafeProfileInformationAsync(string UserId, string FirstName, string Biography,
            DateTime BirthDay, City City, Country Country, EyeColor EyeColor,
            double Height, int Weight, string LastName, LookingFor LookingFor, Sex Sex);

        Task<ProfilePictureServiceModel> EditProfilePictureAsync(string id, int page);


        Task<bool> UploadProfilePictureAsync(IFormFile picture, string userId);

        Task<bool> ChooseProfilePictureAsync(string futurePictureId, string currentPictureId, string userId);

        Task<List<FriendsServiceModel>> GetFriendsAsync(string userId, int page);
        Task<int> GetFriendsMaxPageSizeAsync(string userId);

        Task<bool> DeleteFriendAsync(string userId, string friendId);

        Task<bool> DeletePictureAsync(string pictureId);

    }
}
