
using AutoMapper;
using MeetMe.Services.Models;
using MeetMe.Services.Models.Profile;
using MeetMe.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MeetMe.Common.Mapping;

namespace MeetMe.Web.Areas.Edit.Models
{
    public class EditProfilePictureViewModel:IMapFrom<ProfilePictureServiceModel>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; }

        public int maxPage { get; set; }

        public int currentPage { get; set; }

        public int nextPage { get; set; }

        public int previousPage { get; set; }
        public List<ChildEditProfilePictureViewModel> Pictures { get; set; }

      

        
    }
}
