
using MeetMe.Common.Mapping;
using MeetMe.Data.Models;
using MeetMe.Services.Models.EditProfile.ChildProfilePictureServiceModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Services.Models.EditProfile
{
    public class ProfilePictureServiceModel : IMapFrom<Picture>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; }

        public decimal allPage { get; set; }

        public List<ChildPicturesServiceModel> Pictures { get; set; }

    }
}
