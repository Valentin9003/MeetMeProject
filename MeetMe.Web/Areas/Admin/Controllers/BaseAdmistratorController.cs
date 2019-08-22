using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Admin.Controllers
{
    [Authorize("Adninistrator")]
    [Area("Admin")]
    public abstract class BaseAdministratorController : Controller
    {
       
    }
}