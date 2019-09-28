using MeetMe.Web.Areas.Edit.Models.ChildViewModels;
using System.Collections.Generic;

namespace MeetMe.Web.Areas.Edit.Models
{
    public class FriendsViewModel
    {
        public int currentPage { get; set; }

        public int nextPage { get; set; }

        public int previousPage { get; set; }

        public int allPages { get; set; }

        public List<ChildFriendsViewModel> Friends { get; set; }
    }
}
