using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Search.Controllers
{
    public class SearchController : BaseSearchController
    {
        private readonly UserManager<User> userManager;
        public SearchController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

            
        
        //ToDo: Search

          [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}