using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Search.Models
{
    public class SearchByNameViewModel
    {
        [FromRoute]
        [FromForm]
        public string FirstName { get; set; }

        [FromRoute]
        [FromForm]
        public string LastName { get; set; }

    }
}
