using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement3.Data;

namespace LibraryManagement3.Pages.LibraryBranches
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public CreateModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LibraryBranch LibraryBranch { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LibraryBranches.Add(LibraryBranch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
