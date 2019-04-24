using System;
using System.ComponentModel.DataAnnotations;


namespace MeetMe.Data.Models
{
    public class Comment
    {
        
        public string Id { get; set; }
        [Required]
        public DateTime WritingТime { get; set; }
        
        public string PictureId { get; set; }
        
        public Picture Picture { get; set; }
        [StringLength(300,ErrorMessage = DataConstants.CommentValueMaxLengthErrorMessage)]
        [Required]
        public string CommentValue { get; set; }
         
        public string NotificationId { get; set; }
       
        public Notification Notification { get; set; }
    }
}
