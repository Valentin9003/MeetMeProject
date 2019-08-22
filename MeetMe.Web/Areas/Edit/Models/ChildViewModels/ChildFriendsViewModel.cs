using MeetMe.Common.Mapping;
using MeetMe.Services.Models.EditProfile;

namespace MeetMe.Web.Areas.Edit.Models.ChildViewModels
{
    public class ChildFriendsViewModel : IMapFrom<FriendsServiceModel>
    {

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
