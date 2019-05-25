using MeetMe.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetMe.Services.Models.Profile
{
    public class ProfileInfoServiceModel
    {
       
       public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime BirthDay { get; set; }


        public Sex Sex { get; set; }


        public LookingFor LookingFor { get; set; }


        
        public double Height { get; set; }

        
        public int Weight { get; set; }


        public EyeColor EyeColor { get; set; }
       
        public string Biography { get; set; }
    }
}
