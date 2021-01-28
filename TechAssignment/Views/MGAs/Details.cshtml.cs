using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechAssignment.Data;
using TechAssignment.Models;

namespace TechAssignment.Views.MGAs
{
    public class DetailsModel : PageModel
    {
        private readonly TechAssignment.Data.InsuranceContext _context;

        public DetailsModel(TechAssignment.Data.InsuranceContext context)
        {
            _context = context;
        }

        public MGA MGA { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MGA = await _context.MGA.FirstOrDefaultAsync(m => m.Id == id);

            if (MGA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
