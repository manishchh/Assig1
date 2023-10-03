using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CountryDetailViewModel
    {
        [Key]
        public int CountryId { get; set; }

        public string? CountryName { get; set; }

        [StringLength(255)] 
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }


        public string? RegionName { get; set; }
        public List<CountryYearlyEmissions> CountryYearlyEmissions { get; set; }  
        public List<CountryYearlyTemperature> CountryYearlyTemperature { get; set; }  
    }
}
