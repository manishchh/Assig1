using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CityAirQualityData
    {
        [Required]
        public int Year { get; set; }

        public string? AnnualMeanPmp10 { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Annual Mean PM10 Value")]
        public int? AnnualMeanPmp10Value { get; set; }

        public string? AnnualMeanPmp25 { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Annual Mean PM2.5")]
        public int? AnnualMeanPmp25Value { get; set; }
        public List<AirQualityDataCollectionTypes> AirQualityCollectionTypes { get; set; }
    }
}
