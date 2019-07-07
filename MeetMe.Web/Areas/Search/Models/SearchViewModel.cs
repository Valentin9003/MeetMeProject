using MeetMe.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Search.Models
{
    public class SearchViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public Country Country { get; set; }

        public EyeColor EyeColor { get; set; }

        public LookingFor LookingFor { get; set; }

        public Sex Sex { get; set; }



    }
}
