using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MeetMe.Services;
using MeetMe.Data.Models;
using MeetMe.Web.Areas.Edit.Models;
using System.Security.Claims;
using MeetMe.Data;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MeetMe.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using MeetMe.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using MeetMe.Web.Areas.Edit.Models.ChildViewModels;

namespace MeetMe.Web.Areas.Edit.Controllers
{
    [Authorize]
    public class ProfileController : BaseProfileController

    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IProfileService profileService;
        private readonly MeetMeDbContext context;

        public ProfileController(UserManager<User> userManager, IProfileService profileService,
              MeetMeDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.context = context;
            this.mapper = mapper;

        }



        [HttpGet]
        
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
        public async Task<IActionResult> ProfilePicture(int page = 1)
        {
            /*Async Аction to visualize user profile picture*/

            var user = await userManager.GetUserAsync(User);
            var userId = await userManager.GetUserIdAsync(user);

            var profilePictures = await profileService.EditProfilePictureAsync(userId, page);

            var viewResult = new EditProfilePictureViewModel();
            viewResult.Id = profilePictures.Id;
            viewResult.PictureByteArray = profilePictures.PictureByteArray;
            viewResult.Pictures = profilePictures.Pictures.Select(p =>
           new ChildEditProfilePictureViewModel { PictureByteArray = p.PictureByteArray, Id = p.Id }).ToList();
            viewResult.maxPage = (int)profilePictures.allPage;
            viewResult.previousPage = page - 1;
            viewResult.nextPage = page + 1;
            viewResult.currentPage = page;

            return View(viewResult);
        }
        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile picture)
        {
            /*Async Аction to UPLOAD user profile picture*/
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var userId = user.Id;
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
                nextPage = page + 1,
                previousPage = page - 1,

            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Friends(string friendId)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var userId = user.Id;

             var isSuccessful = await  profileService.deleteFriend(userId, friendId);
           
            if (isSuccessful)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return BadRequest();
        }
    }
}