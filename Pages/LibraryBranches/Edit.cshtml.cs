using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement3.Data;

namespace LibraryManagement3.Pages.LibraryBranches
{
    public class EditModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public EditModel(LibraryManagement3.Data.ApplicationDbContext context)
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

            var librarybranch =  await _context.LibraryBranches.FirstOrDefaultAsync(m => m.LibraryBranchId == id);
            if (librarybranch == null)
            {
                return NotFound();
            }
            LibraryBranch = librarybranch;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LibraryBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryBranchExists(LibraryBranch.LibraryBranchId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LibraryBranchExists(int id)
        {
            return _context.LibraryBranches.Any(e => e.LibraryBranchId == id);
        }
    }
}
