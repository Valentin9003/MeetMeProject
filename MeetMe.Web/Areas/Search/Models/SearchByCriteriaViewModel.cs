using MeetMe.Data.Models.Enums;

namespace MeetMe.Web.Areas.Search.Models
{
    public class SearchByCriteriaViewModel
    {
        public City City { get; set; }

        public Country Country { get; set; }

        public EyeColor EyeColor { get; set; }

        public LookingFor LookingFor { get; set; }

        public Sex Sex { get; set; }
    }
}
