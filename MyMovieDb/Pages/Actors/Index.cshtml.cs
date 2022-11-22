using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Data;
using MyMovieDb.Models;

namespace MyMovieDb.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly MyMovieDb.Data.MovieContext _context;

        public IndexModel(MyMovieDb.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Actors != null)
            {
                Actor = await _context.Actors.ToListAsync();
            }
        }
    }
}
