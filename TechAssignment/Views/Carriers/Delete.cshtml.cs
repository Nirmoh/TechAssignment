using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechAssignment.Data;
using TechAssignment.Models;

namespace TechAssignment.Views.Carriers
{
    public class DeleteModel : PageModel
    {
        private readonly TechAssignment.Data.InsuranceContext _context;

        public DeleteModel(TechAssignment.Data.InsuranceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Carrier Carrier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Carrier = await _context.Carrier.Include(s => s.MGAs)
                .ThenInclude(e => e.Advisors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Carrier == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Carrier = await _context.Carrier.FindAsync(id);

            if (Carrier != null)
            {
                _context.Carrier.Remove(Carrier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
