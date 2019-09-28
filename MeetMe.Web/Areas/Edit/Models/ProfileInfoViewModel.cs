using MeetMe.Common.Mapping;
using MeetMe.Data;
using MeetMe.Data.Models.Enums;
using MeetMe.Services.Models.EditProfile;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Web.Areas.Edit.Models
{
    public class ProfileInfoViewModel : IMapFrom<ProfileInfoServiceModel>
    {
        [Display(Name = "Име")]
        [StringLength(20, ErrorMessage = DataConstants.UserFirstNameMaxLengthErrorMessage)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20, ErrorMessage = DataConstants.UserLastNameMaxLengthErrorMessage)]
        public string LastName { get; set; }
        [Display(Name = "Държава")]
        public Country Country { get; set; }

        [Display(Name = "Град")]
        public City City { get; set; }

        [Display(Name = "Дата на раждане")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Display(Name = "Интересувам се от")]
        public LookingFor LookingFor { get; set; }

        [Display(Name = "Височина")]
        //  [RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage = DataConstants.UserHeightRangeErrorMessage)]
        [Range(0, 2.50, ErrorMessage = DataConstants.UserHeightRangeErrorMessage)]
        public double Height { get; set; }

        [Display(Name = "Тегло")]
        [Range(0, 500, ErrorMessage = DataConstants.UserWeightRangeErrorMessage)]
        public int Weight { get; set; }

        [Display(Name = "Цвят на очите")]
        public EyeColor EyeColor { get; set; }

        [StringLength(500, ErrorMessage = DataConstants.UserBiographyMaxLengthErrorMessage)]
        [Display(Name = "Представяне/Биография")]
        public string Biography { get; set; }
    }
}
