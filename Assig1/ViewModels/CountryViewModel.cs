using Assig1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
