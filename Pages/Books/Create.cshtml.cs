using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement3.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement3.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public CreateModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // public IActionResult OnGet()
        // {
        //     AuthorsList = new SelectList(_context.Authors.ToList(), "AuthorId", "Name");
        //     LibraryBranchesList = new SelectList(_context.LibraryBranches.ToList(), "LibraryBranchId", "BranchName");
        //     return Page();
        // }
        
        public async Task<IActionResult> OnGetAsync()
        {
            AuthorsList = new SelectList(await _context.Authors.ToListAsync(), "AuthorId", "Name");
            LibraryBranchesList = new SelectList(await _context.LibraryBranches.ToListAsync(), "LibraryBranchId", "BranchName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        public SelectList AuthorsList { get; set; }
        public SelectList LibraryBranchesList { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // AuthorsList = new SelectList(await _context.Authors.ToListAsync(), "AuthorId", "Name");
            // LibraryBranchesList = new SelectList(await _context.LibraryBranches.ToListAsync(), "LibraryBranchId", "BranchName");
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
