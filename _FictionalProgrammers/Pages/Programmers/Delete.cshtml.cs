using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _FictionalProgrammers.Pages.Programmers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Programmer Programmer { get; set; }

        public DeleteModel(ApplicationDbContext db)
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

            var programmerFromDb = _db.Programmer.Find(Programmer.Id);
            if (programmerFromDb != null)
            {
                _db.Programmer.Remove(programmerFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Programmer deleted succesfully";
                return RedirectToPage("Index");
            }



            return Page();
        }
    }
}
