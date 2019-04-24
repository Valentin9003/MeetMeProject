using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetMe.Data.Models
{
    public class Notification
    {
       
        public string NotificationId { get; set; }
        [Required]
        public DateTime NotificationТime { get; set; }
        [Required]
        public string informationForNotification { get; set; }
        
        public string UserId { get; set; }
        
        public User User { get; set; }
        
        public string FromUserId { get; set; }
        public string PictureId { get; set; }
       
        public string CommentId { get; set; }
        
        public Comment Comment { get; set; }

       

        
      
    }
}
