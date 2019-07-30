using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Picture
    {

        public string PictureId { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];  // Max size 10MB

        [StringLength(100, ErrorMessage = DataConstants.PictureDescriptionMaxLengthErrorMessage)]
        public string Description { get; set; }

        public bool IsProfilePicture { get; set; } = false;

        public string UserId { get; set; }

        public User User { get; set; }



    }
}
