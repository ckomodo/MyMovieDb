using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMovieDb.Data;
using MyMovieDb.Models;

namespace MyMovieDb.Pages.Actors
{
    public class CreateModel : PageModel
    {
        private readonly MyMovieDb.Data.MovieContext _context;

        public CreateModel(MyMovieDb.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Actor Actor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyActor = new Actor();

            if (await TryUpdateModelAsync<Actor>(
                emptyActor,
                "actor",   // Prefix for form value.
                a => a.FirstName, a => a.LastName, a => a.PlayingAS))
            {
                _context.Actors.Add(emptyActor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }



    }
}
