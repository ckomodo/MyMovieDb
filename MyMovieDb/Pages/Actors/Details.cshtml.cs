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
    public class DetailsModel : PageModel
    {
        private readonly MyMovieDb.Data.MovieContext _context;

        public DetailsModel(MyMovieDb.Data.MovieContext context)
        {
            _context = context;
        }

      public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

                var actor = await _context.Actors
                .Include(s => s.Casts)
                .ThenInclude(e => e.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (actor == null)
            {
                return NotFound();
            }
            else 
            {
                Actor = actor;
            }
            return Page();
        }
    }
}
