using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Programmers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Programmer Programmer { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)//id of object user clicked on in UI
        {
            Programmer = _db.Programmer.Find(id);//Searching for matching id in table Programmer in DB through ctor(_db).Saving it in the Programmer object created above.

            //Programmer = _db.Programmer.FirstOrDefault(u=>u.ProjectID == id);
            //Programmer = _db.Programmer.SingleOrDefault(u => u.ProjectID == id);
            //Programmer = _db.Programmer.Where(u => u.ProjectID == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Programmer.FirstName == Programmer.Competence.ToString())
            {
                ModelState.TryAddModelError("Category.Name", "The Name can´t match Locaton");
            }

            if (ModelState.IsValid)
            {
                _db.Programmer.Update(Programmer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Programmer updated succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
