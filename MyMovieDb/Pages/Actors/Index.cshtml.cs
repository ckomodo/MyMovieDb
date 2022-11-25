using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Data;
using MyMovieDb.Models;
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        //public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Actor> Actors { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Actor> actorsIQ = from a in _context.Actors
                                         select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                actorsIQ = actorsIQ.Where(a => a.LastName.Contains(searchString)
                                       || a.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    actorsIQ = actorsIQ.OrderByDescending(a => a.LastName);
                    break;
                default:
                    actorsIQ = actorsIQ.OrderBy(a => a.LastName);
                    break;
            }

            Actors = await actorsIQ.AsNoTracking().ToListAsync();
        }
    }