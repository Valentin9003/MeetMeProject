using System;
using System.Collections.Generic;
using System.Text;

namespace MeetMe.Services.Models.Profile
{
   public class FriendsServiceModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }


    }
}
