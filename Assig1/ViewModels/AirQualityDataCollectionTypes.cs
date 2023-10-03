using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assig1.Models;


namespace Assig1.ViewModels
{
    public class AirQualityDataCollectionTypes
    {

        public string? StationType { get; set; }
        public int? StationNumber { get; set; }
    }
}
