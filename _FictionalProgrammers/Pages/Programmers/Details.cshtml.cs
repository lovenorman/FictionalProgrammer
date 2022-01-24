using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _FictionalProgrammers.Pages.Programmers
{
    public class DetailsModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Programmer Programmer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programmer = await _db.Programmer.FirstOrDefaultAsync(m => m.Id == id);

            if (Programmer == null)
            {
                return NotFound();
            }
            return Page();
            
        }
    }
}
