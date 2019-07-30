using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Services;
using MeetMe.Web.Areas.Search.Models;
using MeetMe.Web.Areas.Search.Models.ChildViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MeetMe.Web.Areas.Search.Controllers
{

    public class SearchForController : BaseSearchForController
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ISearchService searchService;

        public SearchForController(UserManager<User> userManager, ISearchService searchService, IMapper mapper)
        {
            this.userManager = userManager;
            this.searchService = searchService;
            this.mapper = mapper;
        }



        //ToDo: Search

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var ViewSearchModel = "dsad";

        //    return View(ViewSearchModel);
        //}

        [HttpGet]
        public IActionResult SearchByName()
        {

            var ViewSearchModel = new SearchByNameViewModel();
            TempData["SearchBy"] = "Търсене по име..";
            return View(ViewSearchModel);
        }


        [HttpGet]
        
        //[Route("/Search/SearchFor/SearchByNameResult/{FirstName?}/{LastName?}/{page?}", Name = "SearchByUserName")]
        public async Task<IActionResult> SearchByNameResult(string FirstName, string LastName,int page = 1) //TODO not work routing, page is not binding
        {
            var currentUser = await userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;
            var maxPage = await  searchService.SearchByNameMaxPageSizeAsync(FirstName,LastName, currentUserId);
            var foundUsers = await searchService.SearchByNameAsync(FirstName, LastName, currentUserId, page);
           var foundUsersResult =  mapper.Map<List<ChildSearchResultViewModel>>(foundUsers);

            ViewBag.FirstName =  FirstName;
            ViewBag.LastName =  LastName;

            var viewModel = new SearchResultViewModel()
            {
                PreviousPage = page - 1,
            NextPage = page + 1,
            CurrentPage = page,
            MaxPage = maxPage,
            Results = foundUsersResult,
            };


            return View(viewModel);
        }
        [HttpGet]
        public IActionResult SearchByCriteria()
        {
            var SearchCriteriaViewModel = new SearchByCriteriaViewModel();
            return View(SearchCriteriaViewModel);
        }

        [HttpGet]
        [Route("/Search/SearchFor/SearchByCriteriaResult/{Sex?}/{Country?}/{City?}/{Lookingfor?}/{Eyecolor?}/{page?}")]
        public async Task<IActionResult> SearchByCriteriaResult(SearchByCriteriaViewModel model,[FromRoute]int page = 1)
        {

            var currentUser = await userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;
            var maxPage = await searchService.SearchByCriteriaMaxPageSizeAsync(model.Sex, model.Country, model.City, model.LookingFor, model.EyeColor, currentUserId);
            var foundResults = await searchService.SearchByCriteriaAsync(model.Sex, model.Country, model.City, model.LookingFor, model.EyeColor, currentUserId, page);
            var childModels = mapper.Map<List<ChildSearchResultViewModel>>(foundResults);

            ViewBag.Sex = model.Sex.ToString();
            ViewBag.Country = model.Country.ToString();
            ViewBag.City = model.City.ToString();
            ViewBag.LookingFor = model.LookingFor.ToString();
            ViewBag.EyeColor = model.EyeColor.ToString();

            var ViewModel = new SearchResultViewModel()
            {
                CurrentPage = page,
                PreviousPage = page - 1,
                NextPage = page + 1,
                MaxPage = maxPage,
                Results = childModels,

            };


            

            return View( ViewModel);
        }

        [HttpGet]
        public  IActionResult SearchByUserName()
        {
            var ViewModel = new SearchByUserNameViewModel();

            return View(ViewModel);
        }

        [HttpGet]
        
        public async Task<IActionResult> SearchByUserNameResult(SearchByUserNameViewModel model, [FromRoute]int page = 1 )
        {
           
            var currentUser = await userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;
            var foundResults = await searchService.SearchByUserNameAsync(model.UserName, currentUserId, page);
            var childModels =  mapper.Map<List<ChildSearchResultViewModel>>(foundResults);
            var maxPage = await searchService.SearchByUserNameMaxPageSizeAsync(model.UserName, currentUserId);
            ViewBag.UserName = model.UserName;
            var ViewModel = new SearchResultViewModel()
            {
                CurrentPage = page,
                PreviousPage = page - 1,
                NextPage = page + 1,
                MaxPage = maxPage,
                Results = childModels,

            };
            

            return View(ViewModel);
        }

        [HttpGet]
        [Route("/Search/SearchFor/All/{page?}")]
        public async Task<IActionResult> AllUsers([FromRoute]int page = 1)
        {
            var user = await userManager.GetUserAsync(User);
            var UserId =  user.Id;

            var Users =  await searchService.AllAsync(UserId,page);
            var ChildViewModel = mapper.Map<List<ChildSearchResultViewModel>>(Users);
            int MaxPage = await searchService.AllMaxPageAsync();
            var ViewModel = new SearchResultViewModel()
            {
                CurrentPage = page,
                PreviousPage = page-1,
                NextPage = page+1,
                MaxPage = MaxPage,
                Results = ChildViewModel
            };
            return View(ViewModel);
        }
    }
}