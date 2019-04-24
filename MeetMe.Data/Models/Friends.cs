using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetMe.Data.Models
{
    public class Friends
    {
        
        public string UserId { get; set; }
        public  User User { get; set; }
        
        public string ContactId { get; set; } 
        public  User Contact { get; set; }

        [Required]
        public bool IsAccepted { get; set; }
    }
}
