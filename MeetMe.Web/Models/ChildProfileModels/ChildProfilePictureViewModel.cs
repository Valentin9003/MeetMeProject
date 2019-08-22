using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Models.ChildProfileModels
{
    public class ChildProfilePictureViewModel
    {

        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];  

      
        public string Description { get; set; }
    }
}
