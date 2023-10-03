using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CountryYearlyTemperature
    {

        [Required]
        public int Year { get; set; }

        [Range(0, 100)]

        public decimal MaxCountryTemperature { get; set; }
        [Range(0, 100)]

        public decimal AverageCountryTemperature { get; set; }

        [Range(0, 100)]
        public decimal MinimumCountryTemperature { get; set; }
    }
}
