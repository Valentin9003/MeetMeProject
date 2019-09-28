using System.ComponentModel.DataAnnotations;


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
