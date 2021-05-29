using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AeroLion.Models;
using StockStackApi.Security;

namespace AeroLion.Controllers
{
    public class FlightsController : Controller
    {
        private readonly dbcontext _context;

        public FlightsController(dbcontext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index(LogInViewModel Params)
        {
                return View(await _context.flights.ToListAsync());
        }
        public async Task<IActionResult> Login(LogInViewModel Params)
        {
            customers _customer = new customers();
            _customer = _context.customers.Where(x => x.user_name == Params.Username).FirstOrDefault();
            if (_customer != null && _customer.password == Crypto.Decrypt(Params.Password))
            {

                return RedirectToAction("Index", "Flights");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.flights
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Flight_Id,from_city,to_city,arrival_time,depart_time,fare,max_seats")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flights);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.flights.FindAsync(id);
            if (flights == null)
            {
                return NotFound();
            }
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Flight_Id,from_city,to_city,arrival_time,depart_time,fare,max_seats")] Flights flights)
        {
            if (id != flights.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flights.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flights);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.flights
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flights = await _context.flights.FindAsync(id);
            _context.flights.Remove(flights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int id)
        {
            return _context.flights.Any(e => e.ID == id);
        }
    }
}
