using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AeroportASP;
using AeroportASP.Models;

namespace AeroportASP.Controllers
{
    public class PassInTripsController : Controller
    {
        private readonly aeroContext _context;

        public PassInTripsController(aeroContext context)
        {
            _context = context;
        }

        // GET: PassInTrips
        public async Task<IActionResult> Index()
        {
            var aeroContext = _context.PassInTrips.Include(p => p.IdPsgNavigation).Include(p => p.TripNoNavigation);
            return View(await aeroContext.ToListAsync());
        }

        // GET: PassInTrips/Create
        public IActionResult Create()
        {
            ViewData["Psg"] = new SelectList(_context.Passengers, "IdPsg", "Name");
            ViewData["TripNo"] = new SelectList(_context.Trips, "TripNo", "TripNo");
            return View();
        }

        // POST: PassInTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripNo,Date,IdPsg,Place")] PassInTrip passInTrip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passInTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Psg"] = new SelectList(_context.Passengers, "IdPsg", "Name", passInTrip.IdPsg);
            ViewData["TripNo"] = new SelectList(_context.Trips, "TripNo", "TripNo", passInTrip.TripNo);
            return View(passInTrip);
        }
    }
}
