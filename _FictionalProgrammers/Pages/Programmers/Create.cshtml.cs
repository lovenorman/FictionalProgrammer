using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Programmers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Programmer Programmer { get; set; }

        [BindProperty]
        public List<int> ProjectId { get; set; } = new List<int>();

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            

            if (ModelState.IsValid)
            {
                //ProjectId.ToList().ForEach(x => Programmer.Projects.Add(_db.Project.Find(x)));
                await _db.Programmer.AddAsync(Programmer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Programmer created succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }

        //public async Task<IActionResult> OnPost()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        ProgrammerId.ToList().ForEach(x => Project.Programmer.Add(_db.Programmer.Find(x)));
        //        await _db.Project.AddAsync(Project);
        //        await _db.SaveChangesAsync();
        //        TempData["success"] = "Project created succesfully";
        //        return RedirectToPage("Index");
        //    }

        //    return Page();
        //}
    }
}
