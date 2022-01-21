

using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Project Project { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Project.Name == Project.Location.ToString())
            {
                ModelState.TryAddModelError("Category.Name", "The Name can´t match Locaton");
            }
            
            if(ModelState.IsValid)
            {
                await _db.Project.AddAsync(Project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project created succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
