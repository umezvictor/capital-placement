using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DTOs
{
    
    public class EducationDto
    {

        public string School { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}
