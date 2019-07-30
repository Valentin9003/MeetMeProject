using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Search.Models
{
    public class SearchByUserNameViewModel
    {
        [Display(Name = "Потребителско име")]
        
        public string UserName { get; set; }
    }
}
