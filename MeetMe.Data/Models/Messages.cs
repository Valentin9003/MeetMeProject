using System;
using System.ComponentModel.DataAnnotations;


namespace MeetMe.Data.Models
{
    public class Messages
    {
      
       public string MessagesId { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = DataConstants.MessageMaxLengthErrorMessage)]
        public string Message { get; set; }
        [Required]
        public bool UnreadOrRead { get; set; }   
        [Required]
        public DateTime TimeOfSend { get; set;  }    
        public DateTime TimeOfSeen { get; set; }
       
        public string SenderId { get; set; }  //Current User
       
        public User Sender { get; set; }
       
        public string RecievedId { get; set; }  //Other User
       
        public User Received { get; set; }

    }
}
