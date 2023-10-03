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
                .Include(c=>c.AirQualityData)
                .FirstOrDefaultAsync(m => m.CityId == id);


            if (city == null)
            {
                return NotFound();
            }

            var cityDetails = new CityAirQualityDetailViewModel()
            {
                CityName = city.CityName,
                CountryName = city.Country.CountryName,
                RegionName = city.Country.Region?.RegionName,

                AirQualityData = new List<CityAirQualityData>()
            };
            foreach (var item in city.AirQualityData)
            {
                var airQualityDataCollectionTypes = _context.AirQualityData.Include(a => a.AirQualityStations).Where(x => x.AqdId == item.AqdId).FirstOrDefault();
                cityDetails.AirQualityData.Add(new CityAirQualityData()
                {
                    AnnualMeanPmp10 = item.AnnualMeanPm10,
                    AnnualMeanPmp25 = item.AnnualMeanPm25,
                    AnnualMeanPmp10Value = item.AnnualMean,
                    AnnualMeanPmp25Value = item.AnnualMeanUgm3,
                    Year =item.Year,
                    AirQualityCollectionTypes = airQualityDataCollectionTypes.AirQualityStations.Select(x=> new AirQualityDataCollectionTypes()
                    {
                        StationNumber = x.Number,
                        StationType = x.StationType?.StationType ?? "Unknown"
                        
                    }).ToList() 
                });

            }
            return View(cityDetails);
        }

    }
}
