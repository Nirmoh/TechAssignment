using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechAssignment.Data;
using TechAssignment.Models;

namespace TechAssignment.Views.MGAs
{
    public class CreateModel : PageModel
    {
        private readonly TechAssignment.Data.InsuranceContext _context;

        public CreateModel(TechAssignment.Data.InsuranceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MGA MGA { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MGA.Add(MGA);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
