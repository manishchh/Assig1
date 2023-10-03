using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assig1.Data;
using Assig1.Models;
using Assig1.ViewModels;
using System.Diagnostics.Metrics;

namespace Assig1.Controllers
{
    public class CitiesController : Controller
    {
        private readonly EnvDataContext _context;

        public CitiesController(EnvDataContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index(int? countryId, string searchText="")
        {
         
            if (countryId == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                                        .Include(c => c.Cities)
                                        .ThenInclude(c => c.AirQualityData)
                                        .FirstOrDefaultAsync(c => c.CountryId == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var viewModel = new CityViewModel
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                ImageUrl = country?.ImageUrl,
                RegionName = country?.Region != null? country.Region.RegionName :"N/A",
                Cities = country.Cities
                           .Where(c => string.IsNullOrEmpty(searchText) || c.CityName.StartsWith(searchText))
                           .OrderBy(c => c.CityName)
                           .Select(c => new CityDetailViewModel
                           {
                               CityId = c.CityId,
                               CityName = c.CityName,
                               EarliestYear = c.AirQualityData?.Min(aqd => aqd.Year) ?? 0,
                               LatestYear = c.AirQualityData?.Max(aqd => aqd.Year) ?? 0
                           }).ToList()
            };

            return View(viewModel);
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

    }
}
