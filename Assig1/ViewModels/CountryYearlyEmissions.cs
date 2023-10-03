using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CountryYearlyEmissions
    {
        [Required]
        public int Year { get; set; }

        [StringLength(100)] 
        [Display(Name = "Element Name")]
        public string? ElementName { get; set; }

        [StringLength(100)]
        [Display(Name = "Item Name")]
        public string? ItemName { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Maximum Country Emission")]
        public decimal MaxCountryEmission { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Average Country Emission")]
        public decimal AverageCountryEmission { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimum Country Emission")]
        public decimal MinimumCountryEmission { get; set; }
    }
}
