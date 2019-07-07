using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetMe.Data.Models;
using MeetMe.Services;
using MeetMe.Web.Areas.Search.Models;
using MeetMe.Web.Areas.Search.Models.ChildViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Search.Controllers
{
    public class SearchController : BaseSearchController
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ISearchService searchService;

        public SearchController(UserManager<User> userManager, ISearchService searchService,  IMapper mapper)
        {
            this.userManager = userManager;
            this.searchService = searchService;
            this.mapper = mapper;
        }

            
        
        //ToDo: Search

          [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ViewSearchModel = new SearchViewModel();

            return View(ViewSearchModel);
        }
        [HttpPost("page")]
        
        public async Task<IActionResult> SearchResult(  SearchViewModel model, int page = 1 )
        {
            var currentUser = await userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;
            var maxPage = await searchService.GetSearchMaxPageSizeAsync(model.FirstName, model.LastName, model.Sex, model.Country, model.City, model.LookingFor, model.EyeColor, currentUserId);
           var foundResults = await searchService.SearchAsync(model.FirstName, model.LastName, model.Sex, model.Country, model.City, model.LookingFor, model.EyeColor, page, currentUserId);
            var childModels = mapper.Map<List<ChildSearchResultViewModel>>(foundResults);

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
    }
}