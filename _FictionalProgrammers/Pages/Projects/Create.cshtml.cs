

using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _FictionalProgrammers.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public List<int> ProgrammerId { get; set; } = new List<int>();

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        
        //public void OnGet()
        //{

        //}
        public IActionResult OnGet()
        {
            ViewData["Programmer"] = new MultiSelectList(_db.Programmer.OrderBy(x => x.FirstName), nameof(Programmer.Id), nameof(Programmer.FirstName));
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
           
            if(ModelState.IsValid)
            {
                ProgrammerId.ToList().ForEach(x => Project.Programmer.Add(_db.Programmer.Find(x)));
                await _db.Project.AddAsync(Project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project created succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
