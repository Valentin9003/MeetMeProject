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
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Edit.Controllers
{
    [Authorize]
    public class ProfileController : BaseProfileController

    {
        //TODO

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IProfileService profileService;
        private readonly MeetMeDbContext db;

        public ProfileController(UserManager<User> userManager, IProfileService profileService,
              MeetMeDbContext db, IMapper mapper)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.db = db;
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
        public async Task<IActionResult> ProfilePicture(int page = 1)
        {
            /*Async Аction to visualize user profile picture*/

            var user = await userManager.GetUserAsync(User);
            var userId = await userManager.GetUserIdAsync(user);

            //var jj = db.Picture.Where(p => p.UserId == userId).ToList();
            //var pic = this.db.Users.Where(u => u.Id == userId).Include(p => p.Pictures).Select(a => a.Pictures);
            //List<Picture> ll = db.Users.Where(u => u.Id == userId).Include(p => p.Pictures).FirstOrDefault().Pictures.ToList();
            //     //=== PROBA
            //     //var pic = db.Picture.Where(p => p.UserId == userId).ToList();
            //     //var idlidt = db.Users.Where(u => u.Id == userId).Include(p => p.Pictures).Select(l => l.Id).ToList();
            //     //var userPictures = db.Users.Where(u => u.Id == userId)
            //     //    .Include(o => o.Pictures)
            //     //  .SelectMany(p => p.Pictures).AsQueryable().Select(k => k.PictureByteArray)/*.ToArray();*/;

            //  var model =  db.User.Where(u => u.Id == userId)
            //      .Include(p => p.Pictures).ToList()
            //     .Select(p => new ProfilePictureServiceModel
            //     {
            //         Id = p.Pictures
            //.Where(pp => pp.IsProfilePicture == true)
            //.Select(i => i.PictureId).FirstOrDefault(),

            //         PictureByteArray = p.Pictures
            //.Where(pp => pp.IsProfilePicture == true)
            //.Select(cpp => cpp.PictureByteArray)
            //.FirstOrDefault(),

            //         allPage = (p.Pictures.Count() - 1) % ServicesDataConstraints.EditProfilePictureServicePageSize == 0 ? ((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) : (((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) + 1),//Math.Floor((((decimal)p.Pictures.Count()-1) / ServicesDataConstraints.EditProfilePictureServicePageSize)),

            //         Pictures = p.Pictures
            //.Where(f => f.IsProfilePicture == false)
            //.OrderByDescending(o => o.PictureId)
            //.Skip((page - 1) * ServicesDataConstraints.EditProfilePictureServicePageSize)
            //.Take(ServicesDataConstraints.EditProfilePictureServicePageSize)
            //.Select(k =>
            //new ChildPicturesServiceModel
            //{
            //    PictureByteArray = k.PictureByteArray,
            //    Id = k.PictureId,

            //})
            //.ToList()
            //     }).FirstOrDefault();




            //     //  var model = await db.Users.Where(u => u.Id == userId)
            //     //     .Select(p => new 
            //     //     {
            //     //         Id = p.Pictures
            //     //.Where(pp => pp.isProfilePicture == true)
            //     //.Select(i => i.PictureId).FirstOrDefault(),

            //     //         PictureByteArray = p.Pictures
            //     //.Where(pp => pp.isProfilePicture == true)
            //     //.Select(cpp => cpp.PictureByteArray)
            //     //.FirstOrDefault(),

            //     // allPage = (p.Pictures.Count() - 1) % ServicesDataConstraints.EditProfilePictureServicePageSize == 0 ? ((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) : (((p.Pictures.Count() - 1) / ServicesDataConstraints.EditProfilePictureServicePageSize) + 1),//Math.Floor((((decimal)p.Pictures.Count()-1) / ServicesDataConstraints.EditProfilePictureServicePageSize)),


            //     //.OrderByDescending(o => o.PictureId)
            //     //.Skip((page - 1) * ServicesDataConstraints.EditProfilePictureServicePageSize)
            //     //.Take(ServicesDataConstraints.EditProfilePictureServicePageSize)

            //     //  }).FirstOrDefaultAsync();

            //     var model2 = db.Users.Where(u => u.Id == userId).Include(k => k.Pictures)
            //      // .Include(p=>p.Pictures)
            //      .Select(p => new
            //      {

            //          Pictures = p.Pictures
            // .Where(f => f.IsProfilePicture == false)
            //      });//.AsEnumerable()
            //         //                                        //.OrderByDescending(o => o.PictureId)
            //         //                                        //.Skip((page - 1) * ServicesDataConstraints.EditProfilePictureServicePageSize)
            //         //                                        //.Take(ServicesDataConstraints.EditProfilePictureServicePageSize)

            //     //.Select(k =>
            //     //new
            //     //{
            //     //    //  PictureByteArrayh = k.PictureByteArray,
            //     //    Id = k.PictureId,

            //     //})
            //     //     }).FirstOrDefault();
            //     var model3 =  db.Users.Where(u => u.Id == userId).Include(l => l.Pictures).Select(po => po.Pictures)

            //.ToList();

            // //.OrderByDescending(o => o.PictureId)
            // //.Skip((page - 1) * ServicesDataConstraints.EditProfilePictureServicePageSize)
            // //.Take(ServicesDataConstraints.EditProfilePictureServicePageSize)

            //     //----PROBA

            var profilePictures = await profileService.EditProfilePictureAsync(userId, page);

            var viewResult = new EditProfilePictureViewModel()
            {
                Id = profilePictures.Id,
                PictureByteArray = profilePictures.PictureByteArray,
                Pictures = profilePictures.Pictures.Select(p =>
               new ChildEditProfilePictureViewModel { PictureByteArray = p.PictureByteArray, Id = p.Id }).ToList(), //remove tolist
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


            var isSuccessful = await profileService.DeleteFriendAsync(userId, friendId);

            if (isSuccessful)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home", new { Area = string.Empty });
            }

            return NotFound();
        }
    }
}