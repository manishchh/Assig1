namespace Assig1.ViewModels
{
    public class CountryDetailViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string ImageUrl { get; set; }
        public string RegionName { get; set; }
        public List<CountryYearlyEmissions> CountryYearlyEmissions { get; set; }  
        public List<CountryYearlyTemperature> CountryYearlyTemperature { get; set; }  
    }
}
