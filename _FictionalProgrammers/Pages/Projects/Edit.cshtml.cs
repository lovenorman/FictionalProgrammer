
using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Project Project { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet(int id)//id of object user clicked on in UI
        {
            Project = _db.Project.Find(id);//Searching for matching id in table Project in DB through ctor(_db).Saving it in the Project object created above.

            //Project = _db.Project.FirstOrDefault(u=>u.ProjectID == id);
            //Project = _db.Project.SingleOrDefault(u => u.ProjectID == id);
            //Project = _db.Project.Where(u => u.ProjectID == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            if(Project.Name == Project.Location.ToString())
            {
                ModelState.TryAddModelError("Category.Name", "The Name can´t match Locaton");
            }
            
            if(ModelState.IsValid)
            {
                _db.Project.Update(Project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project updated succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
