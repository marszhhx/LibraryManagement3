using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement3.Data;

namespace LibraryManagement3.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public IndexModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // public IList<Book> Book { get;set; } = default!;
        public IList<BookViewModel> Book { get; set; } = default!;

        // public async Task OnGetAsync()
        // {
        //     Book = await _context.Books.ToListAsync();
        // }
        
        public async Task OnGetAsync()
        {
            var books = await _context.Books.ToListAsync();

            var bookViewModels = books.Select(async book => new
            {
                Book = book,
                AuthorName = await _context.Authors.Where(a => a.AuthorId == book.AuthorId).Select(a => a.Name).FirstOrDefaultAsync(),
                BranchName = await _context.LibraryBranches.Where(lb => lb.LibraryBranchId == book.LibraryBranchId).Select(lb => lb.BranchName).FirstOrDefaultAsync()
            }).ToList();

            // Await all async operations and then project into BookViewModel
            Book = (await Task.WhenAll(bookViewModels)).Select(b => new BookViewModel
            {
                BookId = b.Book.BookId,
                Title = b.Book.Title,
                AuthorName = b.AuthorName ?? "Unknown Author",
                LibraryBranchName = b.BranchName ?? "Unknown Branch"
            }).ToList();
        }

    }
}
