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

    public class IndexModel : PageModel
    {
        private readonly LibraryManagement3.Data.ApplicationDbContext _context;

        public IndexModel(LibraryManagement3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LibraryBranch> LibraryBranch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LibraryBranch = await _context.LibraryBranches.ToListAsync();
        }
    }
}
