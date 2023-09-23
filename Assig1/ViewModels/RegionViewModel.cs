using Assig1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class RegionViewModel
    {
        [Display(Name = "Region")]
        public int? SelectedRegionId { get; set; }

        [StringLength(100, ErrorMessage = "The country name cannot exceed 80 characters.")]
        [Display(Name = "Country Name")]
        public string? SearchText { get; set; }

        public List<Region> Regions { get; set; }
    }
}
