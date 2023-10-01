namespace Assig1.ViewModels
{
    public class CountryYearlyEmissions
    {
        public int Year { get; set; }
        public string ElementName { get; set; }  
        public string ItemName { get; set; }     
        public decimal MaxCountryEmission { get; set; }
        public decimal AverageCountryEmission { get; set; }
        public decimal MinimumCountryEmission { get; set; }
    }
}
