using MeetMe.Web.Areas.Search.Models.ChildViewModels;
using System.Collections.Generic;

namespace MeetMe.Web.Areas.Search.Models
{
    public class SearchResultViewModel
    {
        public int MaxPage { get; set; }

        public int CurrentPage { get; set; }

        public int NextPage { get; set; }

        public int PreviousPage { get; set; }

        public List<ChildSearchResultViewModel> Results { get; set; } = new List<ChildSearchResultViewModel>();
    }
}
