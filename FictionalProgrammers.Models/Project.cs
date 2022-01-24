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


        [DisplayName("Programmer")]
        //public Programmer? Programmer { get; set; }

        //public List<Programmer_Project> Programmer_Projects { get; set; }

        public List<Programmer> Programmer { get; set; } = new List<Programmer>();  

        public string PrintAllProgrammers()
        {
            string programmer = string.Empty;
            Programmer.ForEach(p => programmer += $" {p.FirstName}" );
            return programmer;
        }

        [DisplayName("Created")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


        [DisplayName("End Date")]
        public DateTime EndDateTime { get; set; }


        public ProjectCategory Category { get; set; }

        
        public ProjectLocation Location { get; set; }
    }
}
