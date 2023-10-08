using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   
    public class PersonalInformation
    {
        public PersonalInformation()
        {
            AdditionalQuestions = new Dictionary<string, string>();
        }
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("nationality")]
        public string Nationality { get; set; } = string.Empty;

        [JsonProperty("residence")]
        public string Residence { get; set; } = string.Empty;
        [JsonProperty("idNumber")]
        public string IdNumber { get; set; } = string.Empty;

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;

        public Dictionary<string, string> AdditionalQuestions { get; set; }
    }

}
