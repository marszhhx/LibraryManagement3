using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement3.Data;
using Microsoft.AspNetCore.Authorization;


namespace LibraryManagement3.Pages.LibraryBranches
{
    [Authorize]

    public class DeleteModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public DeleteModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarybranch = await _context.LibraryBranches.FindAsync(id);
            if (librarybranch != null)
            {
                LibraryBranch = librarybranch;
                _context.LibraryBranches.Remove(LibraryBranch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
