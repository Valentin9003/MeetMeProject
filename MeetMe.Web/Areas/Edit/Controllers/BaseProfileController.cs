using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Web.Areas.Edit
{
    [Area("Edit")]
    public abstract class BaseProfileController : Controller
    {
    }
}