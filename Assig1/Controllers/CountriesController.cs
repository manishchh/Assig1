﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assig1.Data;
using Assig1.Models;
using Assig1.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;

namespace Assig1.Controllers
{
    public class CountriesController : Controller
    {
        private readonly EnvDataContext _context;

        public CountriesController(EnvDataContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index(int? regionId)
        {
            //Queryable<Country> query = _context.Countries;
            List<CountryViewModel> countries;

            if (regionId.HasValue && regionId.Value != 0)
            {
                countries = await _context.Countries
                    .Where(c =>  c.RegionId == regionId.Value)
                    .OrderBy(c => c.CountryName)
                    .Select(c => new CountryViewModel
                    {
                        CountryId = c.CountryId,
                        CountryName = c.CountryName,   
                        RegionName = c.Region != null? c.Region.RegionName : "N/A",
                        ImageUrl = c.ImageUrl
                    })
                    .ToListAsync();

               
            }
            else
            {
                countries = await _context.Countries
                   .OrderBy(c => c.CountryName)
                   .Select(c => new CountryViewModel
                   {
                       CountryId = c.CountryId,
                       CountryName = c.CountryName,
                       RegionName = c.Region != null? c.Region.RegionName : "N/A",
                       ImageUrl = c.ImageUrl
                   })
                   .ToListAsync();
            }
           

            return View(countries);
            //var envDataContext = _context.Countries.Include(c => c.Region);
            //return View(await envDataContext.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.Region)
                .Include(c => c.TemperatureData)
                .Include(c => c.CountryEmissions)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }
            var countryDetailsVewModel = new CountryDetailViewModel()
            {
                CountryName = country.CountryName,
                ImageUrl = country.ImageUrl,
                RegionName = country.Region?.RegionName ?? "N/A",
                CountryYearlyEmissions = country.CountryEmissions.GroupBy(x => x.Year)
                .Select(x => new CountryYearlyEmissions
                {
                    Year = x.Key ?? 0,
                    ElementName = x.FirstOrDefault()?.ItemElement?.Element.ElementName ?? "N/A",
                    ItemName = x.FirstOrDefault()?.ItemElement?.Item.ItemName ?? "N/A",
                    AverageCountryEmission = x.Average(y => y.Value) ?? 0,
                    MaxCountryEmission = x.Max(y => y.Value) ?? 0,
                    MinimumCountryEmission = x.Min(y => y.Value) ?? 0
                }).ToList()
               
            };

            return View(countryDetailsVewModel);
        }
    }
}

      