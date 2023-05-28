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
        [Route("PassInTrips/CreateForPsg/{id_psg}")]
        public IActionResult CreateForPsg(int id_psg)
        {
            ViewData["TripNo"] = new SelectList(_context.Trips, "TripNo", "TripNo");
            return View();
        }

        // POST: PassInTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PassInTrips/CreateForPsg/{id_psg}")]
        public async Task<IActionResult> CreateForPsg(int id_psg, [Bind("TripNo,Date,Place")] PassInTrip passInTrip)
        {
            passInTrip.IdPsg = id_psg;
            if (ModelState.IsValid)
            {
                _context.Add(passInTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passInTrip);
        }
        
        [Route("PassInTrips/CreateForTrip/{trip_no}")]
        public IActionResult CreateForTrip(int trip_no)
        {
            ViewData["Pass"] = new SelectList(_context.Passengers, "IdPsg", "Name");
            return View();
        }

        // POST: PassInTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PassInTrips/CreateForTrip/{trip_no}")]
        public async Task<IActionResult> CreateForTrip(int trip_no, [Bind("Date,IdPsg,Place")] PassInTrip passInTrip)
        {
            passInTrip.TripNo = trip_no;
            if (ModelState.IsValid)
            {
                _context.Add(passInTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passInTrip);
        }

        [Route("PassInTrips/{id_psg}/{trip_no}")]
        public async Task<IActionResult> Delete(int id_psg, int trip_no)
        {
            var passInTrip = await _context.PassInTrips.Include("IdPsgNavigation")
                .Where(p => p.IdPsg == id_psg && p.TripNo == trip_no).FirstOrDefaultAsync();
            return View(passInTrip);
        }

        [HttpPost, ActionName("Delete")]
        [Route("PassInTrips/{id_psg}/{trip_no}")]
        public async Task<IActionResult> DeleteConfirmed(int id_psg, int trip_no)
        {
            var passInTrip = await _context.PassInTrips.Include("IdPsgNavigation")
                .Where(p => p.IdPsg == id_psg && p.TripNo == trip_no).FirstOrDefaultAsync();
            _context.PassInTrips.Remove(passInTrip);
            _context.SaveChanges();
            return Redirect($"/Trips/Passengers/{trip_no}");
        }
    }
}
