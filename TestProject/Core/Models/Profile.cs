using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   
   

    public class Profile
    {
        public Profile()
        {
            AdditionalQuestions = new Dictionary<string, string>();
            Education = new List<Education>();
            Experience = new List<Experience>();
        }

        [JsonProperty("education")]
        public List<Education>? Education { get; set; }

        [JsonProperty("experience")]
        public List<Experience>? Experience { get; set; }

        [JsonProperty("resumeid")]
        public string ResumeId { get; set; } = string.Empty;
        public Dictionary<string, string> AdditionalQuestions { get; set; }

    }

}
