namespace Assig1.ViewModels
{
    public class CityViewModel
    {
       
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? ImageUrl { get; set; }
        public string? RegionName { get; set; }
        public List<CityDetailViewModel> Cities { get; set; }
    }
}
