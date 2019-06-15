using MeetMe.Web.Areas.Edit.Models.ChildViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Edit.Models
{
    public class FriendsViewModel
    {
        public int currentPage { get; set; }
        public int nextPage { get; set; }
        public int previousPage { get; set; }

        public int allPages { get; set; }

        public List<ChildFriendsViewModel> Friends {get;set;}
    }
}
