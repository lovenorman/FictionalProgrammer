
using FictionalProgrammers.DataAccess;
using FictionalProgrammers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _FictionalProgrammers.Pages.Projects
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public string SortOrder { get; set; }

        public IList<Project> Projects { get; set; }
        
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task OnGetAsync(string SortOrder)
        {
            Projects = await _db.Project.Include(x => x.Programmer).ToListAsync();
            SortOrder = string.IsNullOrEmpty(SortOrder) ? "" : SortOrder;
            Projects = SortOrder switch
            {
                "?sort=titleasc" => Projects.OrderBy(b => b.Name).ToList(),
                "?sort=titledesc" => Projects.OrderByDescending(b => b.Name).ToList(),
                //"?sort=programmerasc" => Projects.OrderBy(b => b.Programmer).ToList(),
                //"?sort=programmerdesc" => Projects.OrderByDescending(b => b.Programmer).ToList(),
                "?sort=categoryasc" => Projects.OrderBy(b => b.Category.ToString()).ToList(),
                "?sort=categorydesc" => Projects.OrderByDescending(b => b.Category.ToString()).ToList(),
                "?sort=locationasc" => Projects.OrderBy(b => b.Location.ToString()).ToList(),
                "?sort=locationdesc" => Projects.OrderByDescending(b => b.Location.ToString()).ToList(),
                _ => Projects.OrderBy(b => b.Name).ToList()
            };
        }
        
        //public void OnGet()
        //{
        //    Projects = _db.Project;
        //}
    }
}
