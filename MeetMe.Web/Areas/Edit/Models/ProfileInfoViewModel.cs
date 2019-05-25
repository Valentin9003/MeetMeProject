using AutoMapper;
using MeetMe.Data;
using MeetMe.Data.Models;
using MeetMe.Data.Models.Enums;
using MeetMe.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Areas.Edit.Models
{
    public class ProfileInfoViewModel
    {
        [Display(Name ="Име")]
      [StringLength(20, ErrorMessage = DataConstants.UserFirstNameMaxLengthErrorMessage)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(20, ErrorMessage = DataConstants.UserLastNameMaxLengthErrorMessage)]
        public string LastName { get; set; }
        [Display(Name = "Държава")]
        [StringLength(30, ErrorMessage = DataConstants.UserCountryMaxLengthErrorMessage)]
        public string Country { get; set; }
        [Display(Name = "Град")]
        [StringLength(20, ErrorMessage = DataConstants.UserCityMaxLengthErrorMessage)]
        public string City { get; set; }
        [Display(Name = "Дата на раждане")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Display(Name = "Интересувам се от")]
        public LookingFor LookingFor { get; set; }

        [Display(Name = "Височина")]
        [RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage = DataConstants.UserHeightRangeErrorMessage)]
        [Range(1, 2.50)]
        public double Height { get; set; }
        [Display(Name = "Тегло")]
       [Range(1,500)]
        public int Weight { get; set; }

        [Display(Name = "Цвят на очите")]
        public EyeColor EyeColor { get; set; }
        [StringLength(500, ErrorMessage = DataConstants.UserBiographyMaxLengthErrorMessage)]
        [Display(Name = "Представяне/Биография")]
        public string Biography { get; set; }

        
        
    }
}
