using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalProgrammers.Models
{
    public class Programmer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Competence { get; set; }

        [DisplayName("Project")]
        public List<Project> Projects { get; set; } = new List<Project>();

        public string PrintAllProjects()
        {
            string project = string.Empty;
            Projects.ForEach(p => project += $" {p.Name}");
            return project;
        }

        //public List<Programmer_Project> Programmer_Projects { get; set; }

        //public ProgrCompetence Competence { get; set; }

        //public List<Project> Projects { get; set; } 


    }
}
