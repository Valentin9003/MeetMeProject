using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models
{
    public class Friends
    {
        public string UserId { get; set; }     //UserSender

        public User User { get; set; }

        public string ContactId { get; set; }  //UserRecipient

        public User Contact { get; set; }

        [Required]
        public bool IsAccepted { get; set; }
    }
}
