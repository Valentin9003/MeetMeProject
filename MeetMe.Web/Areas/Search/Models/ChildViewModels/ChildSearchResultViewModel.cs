using MeetMe.Common.Mapping;
using MeetMe.Services.Models.Search;

namespace MeetMe.Web.Areas.Search.Models.ChildViewModels
{
    public class ChildSearchResultViewModel : IMapFrom<SearchServiceModel>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] PrifilePicture { get; set; } = new byte[10 * 1024 * 1024];
    }
}
