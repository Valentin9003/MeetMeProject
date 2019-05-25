using MeetMe.Services.Models.Profile;
using MeetMe.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Edit.Models.ChildViewModels
{
    public class ChildFriendsViewModel:IMapFrom<FriendsServiceModel>
    {
        
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
