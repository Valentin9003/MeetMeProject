using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Admin.Controllers
{
    public class AdministratorController : BaseAdministratorController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}