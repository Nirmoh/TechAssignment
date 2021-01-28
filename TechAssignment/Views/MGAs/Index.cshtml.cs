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
    public class IndexModel : PageModel
    {
        private readonly TechAssignment.Data.InsuranceContext _context;

        public IndexModel(TechAssignment.Data.InsuranceContext context)
        {
            _context = context;
        }

        public IList<MGA> MGA { get;set; }

        public async Task OnGetAsync()
        {
            MGA = await _context.MGA.ToListAsync();
        }
    }
}
