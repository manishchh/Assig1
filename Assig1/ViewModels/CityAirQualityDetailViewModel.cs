namespace Assig1.ViewModels
{
    public class CityAirQualityDetailViewModel
    {
        public string CityName { get; set; }
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
        public List<CityAirQualityData> AirQualityData { get; set; }
    }

}
