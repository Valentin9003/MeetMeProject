using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MeetMe.Web.Areas.Edit.Models
{
    public class ChildEditProfilePictureViewModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; }



      
    }
}
