using MeetMe.Data.Models.Enums;
using MeetMe.Web.Models.ChildProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture = new byte[10 * 10 * 1024];

        public bool IsOnline { get; set; }

        public DateTime LastEntryDate { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public DateTime BirthDay { get; set; }

        public Sex Sex { get; set; }

        public LookingFor LookingFor { get; set; }

        public double Height { get; set; }

        public int Weight { get; set; }

        public string Biography { get; set; }

        public List<ChildProfilePictureViewModel> Pictures { get; set; } = new List<ChildProfilePictureViewModel>();

        public List<ChildProfileFriendsViewModel> Friends { get; set; } = new List<ChildProfileFriendsViewModel>();
    }
}
