using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DTOs
{
   
    public class PersonalInformationDto
    {
        public PersonalInformationDto()
        {
            AdditionalQuestions = new Dictionary<string, string>();
        }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Residence { get; set; } = string.Empty;

        public string IdNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Dictionary<string, string> AdditionalQuestions { get; set; }
    }
}
