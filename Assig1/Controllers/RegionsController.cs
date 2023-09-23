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

namespace Assig1.Controllers
{
    public class RegionsController : Controller
    {
        private readonly EnvDataContext _context;

        public RegionsController(EnvDataContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index(RegionViewModel vm)
        {
            // This is the only ViewBag you can use to set the active Menu Item.
            ViewBag.Active = "Regions";

            IQueryable<Region> query = _context.Regions;

            // filter by selected region
            if (vm.SelectedRegionId.HasValue)
            {
                query = query
                    .Where(r => r.RegionId == vm.SelectedRegionId);
            }

            // Filter by search text
            if (!string.IsNullOrEmpty(vm.SearchText))
            {
                query = query
                    .Where(r => r.RegionName
                    .Contains(vm.SearchText, StringComparison.OrdinalIgnoreCase));
            }

            vm.Regions = await query
                .OrderBy(r => r.RegionName)
                .ToListAsync();

            return View(vm);
            //var regions = await _context.Regions
            //    .OrderBy(r => r.RegionName)
            //    .ToListAsync();

            //return _context.Regions != null ? 
            //              View(await _context.Regions.ToListAsync()) :
            //              Problem("Entity set 'EnvDataContext.Regions'  is null.");
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Regions == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        private bool RegionExists(int id)
        {
          return (_context.Regions?.Any(e => e.RegionId == id)).GetValueOrDefault();
        }
    }
}
