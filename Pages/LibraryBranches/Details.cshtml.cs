using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement3.Data;

namespace LibraryManagement3.Pages.LibraryBranches
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public DetailsModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public LibraryBranch LibraryBranch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarybranch = await _context.LibraryBranches.FirstOrDefaultAsync(m => m.LibraryBranchId == id);
            if (librarybranch == null)
            {
                return NotFound();
            }
            else
            {
                LibraryBranch = librarybranch;
            }
            return Page();
        }
    }
}
