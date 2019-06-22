using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetMe.Services.Models.Profile.ChildProfilePictureServiceModels
{
   public class ChildPicturesServiceModel
    {
        public string Id { get; set; }

     //DODO   [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; }
    }
}
