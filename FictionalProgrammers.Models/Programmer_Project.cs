using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalProgrammers.Models
{
    public class Programmer_Project
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int ProgrammerId { get; set; }

        public  Programmer Programmer { get; set; }
    }
}
