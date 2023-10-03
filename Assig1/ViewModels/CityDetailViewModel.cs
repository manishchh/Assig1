using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CityDetailViewModel
    {
        [Key]
        public int CityId { get; set; }

        public string? CityName { get; set; }

        [Range(2000, 2025)]
        [Display(Name = "Earliest Year")]
        public int EarliestYear { get; set; }


        [Range(2000, 2025)]
        [Display(Name = "Earliest Year")]
        public int LatestYear { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Air Quality Data Count")]
        public int AirQualityDataCount { get; set; }
        
    }
}
