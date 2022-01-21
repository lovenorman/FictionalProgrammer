
using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Project Project { get; set; }

        public DeleteModel(ApplicationDbContext db)
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
            
                var projectFromDb = _db.Project.Find(Project.Id);
                if(projectFromDb != null)
                {
                    _db.Project.Remove(projectFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Project deleted succesfully";
                    return RedirectToPage("Index");
                }
                
            

            return Page();
        }
    }
}
