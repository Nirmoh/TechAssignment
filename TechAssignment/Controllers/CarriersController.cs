using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechAssignment.Data;
using TechAssignment.Models;

namespace TechAssignment.Controllers
{
    public class CarriersController : Controller
    {
        private readonly InsuranceContext _context;

        public CarriersController(InsuranceContext context)
        {
            _context = context;
        }

        // GET: Carriers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrier.ToListAsync());
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier
                .Include(s => s.MGAs)
                .ThenInclude(e => e.Advisors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BussinessName,BussinessAddress,BussinessPhoneNumber")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrier);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }
            return View(carrier);
        }

        // POST: Carriers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BussinessName,BussinessAddress,BussinessPhoneNumber")] Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierExists(carrier.Id))
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
            return View(carrier);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrier = await _context.Carrier.FindAsync(id);
            _context.Carrier.Remove(carrier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierExists(int id)
        {
            return _context.Carrier.Any(e => e.Id == id);
        }
    }
}
