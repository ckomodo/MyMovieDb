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
    public class DeleteModel : PageModel
    {
        private readonly MyMovieDb.Data.MovieContext _context;

        public DeleteModel(MyMovieDb.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }
            var actor = await _context.Actors.FindAsync(id);

            if (actor != null)
            {
                Actor = actor;
                _context.Actors.Remove(Actor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
