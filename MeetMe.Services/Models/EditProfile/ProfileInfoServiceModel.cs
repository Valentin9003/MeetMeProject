using MeetMe.Common.Mapping;
using MeetMe.Data.Models;
using MeetMe.Data.Models.Enums;
using System;

namespace MeetMe.Services.Models.EditProfile
{
    public class ProfileInfoServiceModel : IMapFrom<User>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public Country City { get; set; }

        public DateTime BirthDay { get; set; }


        public Sex Sex { get; set; }


        public LookingFor LookingFor { get; set; }



        public double Height { get; set; }


        public int Weight { get; set; }


        public EyeColor EyeColor { get; set; }

        public string Biography { get; set; }


    }
}
