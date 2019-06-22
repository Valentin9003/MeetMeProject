
using MeetMe.Data.Models;
using MeetMe.Common.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper.Configuration;
using MeetMe.Services.Models.Profile.ChildProfilePictureServiceModels;

namespace MeetMe.Services.Models.Profile
{
   public class ProfilePictureServiceModel:IMapFrom<Picture>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; }

       public  decimal allPage { get; set; }

        public List<ChildPicturesServiceModel> Pictures { get; set; }

    }
}
