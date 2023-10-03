namespace Assig1.ViewModels
{
    public class CityAirQualityData
    {
        public int Year { get; set; }
        public string? AnnualMeanPmp10 { get; set; }
        public int? AnnualMeanPmp10Value { get; set; }
        public string? AnnualMeanPmp25 { get; set; }
        public int? AnnualMeanPmp25Value { get; set; }
        public List<AirQualityDataCollectionTypes> AirQualityCollectionTypes { get; set; }
    }
}
