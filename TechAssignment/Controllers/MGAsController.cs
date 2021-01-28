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
    public class MGAsController : Controller
    {
        private readonly InsuranceContext _context;

        public MGAsController(InsuranceContext context)
        {
            _context = context;
        }

        // GET: MGAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MGA.ToListAsync());
        }

        // GET: MGAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mGA = await _context.MGA
                .Include(s => s.Advisors)
                .Include(e => e.Carriers)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mGA == null)
            {
                return NotFound();
            }

            return View(mGA);
        }

        // GET: MGAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MGAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BussinessName,BussinessAddress,BussinessPhoneNumber")] MGA mGA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mGA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mGA);
        }

        // GET: MGAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mGA = await _context.MGA.FindAsync(id);
            if (mGA == null)
            {
                return NotFound();
            }
            return View(mGA);
        }

        // POST: MGAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BussinessName,BussinessAddress,BussinessPhoneNumber")] MGA mGA)
        {
            if (id != mGA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mGA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MGAExists(mGA.Id))
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
            return View(mGA);
        }

        // GET: MGAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mGA = await _context.MGA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mGA == null)
            {
                return NotFound();
            }

            return View(mGA);
        }

        // POST: MGAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mGA = await _context.MGA.FindAsync(id);
            _context.MGA.Remove(mGA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MGAExists(int id)
        {
            return _context.MGA.Any(e => e.Id == id);
        }
    }
}
