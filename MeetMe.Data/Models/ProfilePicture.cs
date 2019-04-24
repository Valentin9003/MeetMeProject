using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetMe.Data.Models
{
    public class ProfilePicture
    {

        public string Id { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];  // Max size 10MB

        [StringLength(100, ErrorMessage = DataConstants.PictureDescriptionMaxLengthErrorMessage)]
        public string Description { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
       
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
