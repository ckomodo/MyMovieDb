using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Data;
using MyMovieDb.Models;

namespace MyMovieDb.Pages.Actors
{
    public class EditModel : PageModel
    {
        private readonly MyMovieDb.Data.MovieContext _context;

        public EditModel(MyMovieDb.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actor Actor { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Actors == null)
        //    {
        //        return NotFound();
        //    }

        //    var actor =  await _context.Actors.FirstOrDefaultAsync(m => m.ID == id);
        //    if (actor == null)
        //    {
        //        return NotFound();
        //    }
        //    Actor = actor;
        //    return Page();
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Actor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ActorExists(Actor.ID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FindAsync(id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var actorToUpdate = await _context.Actors.FindAsync(id);

            if (actorToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Actor>(
                actorToUpdate,
                "actor",
                a => a.FirstName, a => a.LastName, a => a.PlayingAS))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        private bool ActorExists(int id)
        {
          return _context.Actors.Any(e => e.ID == id);
        }
    }
}
