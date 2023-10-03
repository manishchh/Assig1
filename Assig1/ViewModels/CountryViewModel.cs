using Assig1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assig1.ViewModels
{
    public class CountryViewModel
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(60)] 
        [Display(Name = "Country Name")]
        public string? CountryName { get; set; }

        [StringLength(100)] 
        [Display(Name = "Region Name")]
        public string? RegionName { get; set; }

        [StringLength(255)] 
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
    }
}
