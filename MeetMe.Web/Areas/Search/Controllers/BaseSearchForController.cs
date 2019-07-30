using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Search.Controllers
{
    [Area("Search")]
    [Authorize]
    public abstract class BaseSearchForController : Controller
    {

    }
}