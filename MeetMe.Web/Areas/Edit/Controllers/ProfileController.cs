using AutoMapper;
using MeetMe.Data;
using MeetMe.Data.Models;
using MeetMe.Services;
using MeetMe.Web.Areas.Edit.Models;
using MeetMe.Web.Areas.Edit.Models.ChildViewModels;
using MeetMe.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Edit.Controllers
{
    [Authorize]
    public class ProfileController : BaseProfileController

    {


        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IEditProfileService profileService;


        public ProfileController(UserManager<User> userManager, IEditProfileService profileService, IMapper mapper)
        {
            this.userManager = userManager;

            this.profileService = profileService;

            this.mapper = mapper;

        }


        [HttpGet]
        [Route("Edit/Profile/Info")]
        public async Task<IActionResult> Info()
        {

            /*Async Аction to visualize user profile information*/

            if (!User.Identity.IsAuthenticated)
            {
                return NotFound(ProjectConstants.UnregisteredUserErrorMessage);
            }

            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            var userId = await userManager.GetUserIdAsync(user);

            var profileInfo = await profileService.GetProfileInformationAsync(userId);

            var model = mapper.Map<ProfileInfoViewModel>(profileInfo);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Info([FromForm]ProfileInfoViewModel model)
        {
            /*Async Аction to change user profile information*/
            if (!ModelState.IsValid)
            {
                var r = ModelState.DefaultIfEmpty();
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            var userId = await userManager.GetUserIdAsync(user);

            var TryToSafe = await profileService.SafeProfileInformationAsync(userId, model.FirstName,
                 model.Biography,
             model.BirthDay,
             model.City,
             model.Country,
             model.EyeColor,
             model.Height,
             model.Weight,
             model.LastName,
             model.LookingFor,
             model.Sex);

            if (TryToSafe)
            {
                TempData["SaveChanges"] = "Успешно записахте промените!";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return View(model);
        }

        [HttpGet]
        [Route("Edit/Profile/ProfilePicture/{page?}")]
        public async Task<IActionResult> ProfilePicture(int page = 1)
        {
            /*Async Аction to visualize user profile picture*/

            var user = await userManager.GetUserAsync(User);

            var userId = await userManager.GetUserIdAsync(user);

            var profilePictures = await profileService.EditProfilePictureAsync(userId, page);

            var viewResult = new EditProfilePictureViewModel()
            {
                Id = profilePictures.Id,
                PictureByteArray = profilePictures.PictureByteArray,
                Pictures = profilePictures.Pictures.Select(p =>
               new ChildEditProfilePictureViewModel { PictureByteArray = p.PictureByteArray, Id = p.Id }).ToList(),
                maxPage = (int)profilePictures.allPage,
                previousPage = page - 1,
                nextPage = page + 1,
                currentPage = page,
            };

            var userZaBreakPiont = await userManager.GetUserAsync(User);

            return View(viewResult);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile picture)
        {
            /*Async Аction to UPLOAD user profile picture*/
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            var userId = user.Id;

            if (Path.GetExtension(picture.FileName).ToLower() != ".jpg"
                          && Path.GetExtension(picture.FileName).ToLower() != ".png"
                          && Path.GetExtension(picture.FileName).ToLower() != ".gif"
                          && Path.GetExtension(picture.FileName).ToLower() != ".jpeg")
            {
                TempData["FormatError"] = "Файлът трябва да бъде един от следните формати: .JPG .PNG .GIF .JPEG";

                return RedirectToAction(nameof(ProfileController.ProfilePicture), "Profile", new { Area = "Edit" });

            }

            var isSuccessful = await profileService.UploadProfilePictureAsync(picture, userId);

            if (isSuccessful)
            {
                TempData["SaveChanges"] = "Успешно добавихте нова профилна снимка!";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> ChooseProfilePicture(string futurePictureId, string currentPictureId)
        {
            /*Async Аction to visualize the current user friends */

            var user = await userManager.GetUserAsync(User);

            var userId = user.Id;

            var isSuccessful = await profileService.ChooseProfilePictureAsync(futurePictureId, currentPictureId, userId);

            if (isSuccessful)
            {
                TempData["SaveChanges"] = "Успешно променихте вашата профилна снимка!";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePicture(string pictureId)
        {
            var isSuccessful = await profileService.DeletePictureAsync(pictureId);

            if (isSuccessful)
            {
                TempData["SaveChanges"] = "Успешно изтрихте снимка!";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Friends(int page = 1)
        {
            /*Async Аction to select user profile picture from the currents pictures*/
            var user = await userManager.GetUserAsync(User);
            var userId = user.Id;

            var friendsListResult = await profileService.GetFriendsAsync(userId, page);

            var friendsList = mapper.Map<List<ChildFriendsViewModel>>(friendsListResult);

            var maxPage = await profileService.GetFriendsMaxPageSizeAsync(userId);

            FriendsViewModel model = new FriendsViewModel()
            {
                Friends = friendsList,
                allPages = maxPage,
                currentPage = page,
                nextPage = (page + 1),
                previousPage = (page - 1),

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Friends(string friendId)
        {
            /*Async Аction to delete user picture from the currents pictures*/
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            var userId = user.Id;

            var isSuccessful = await profileService.DeleteFriendAsync(userId, friendId);

            if (isSuccessful)
            {
                TempData["SaveChanges"] = "Успешно премахнахте приятел от  списъка!";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return NotFound();
        }
    }
}