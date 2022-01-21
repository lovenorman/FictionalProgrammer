using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FictionalProgrammers.Models
{
    public class Project
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public List<Programmer> Programmers { get; set; }   
        //public List<Progr_Project> Progr_Projects { get; set; } 

        [DisplayName("Start Date")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


        [DisplayName("End Date")]
        public DateTime EndDateTime { get; set; }

        public string Category { get; set; }
        //public ProjectCategory Category { get; set; }

        public string Location { get; set; }
        //public ProjectLocation Location { get; set; }
    }
}
