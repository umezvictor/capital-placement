using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   

    public class InternshipProgram
    {
        public InternshipProgram()
        {
            Id = Guid.NewGuid().ToString();
            Skills = new List<string>();
            Benefits = new List<string>();
            Criteria = new List<string>();
        }
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("summary")]
        public string Summary { get; set; } = string.Empty;
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("skills")]
        public List<string> Skills { get; set; }

        [JsonProperty("benefits")]
        public List<string> Benefits { get; set; }

        [JsonProperty("criteria")]
        public List<string> Criteria { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        [JsonProperty("programStart")]
        public DateTime ProgramStart { get; set; }

        [JsonProperty("applicationOpen")]
        public DateTime ApplicationOpen { get; set; }

        [JsonProperty("applicationClose")]
        public DateTime ApplicationClose { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("programLocation")]
        public string ProgramLocation { get; set; } = string.Empty;

        [JsonProperty("minimumQualification")]
        public string MinimumQualification { get; set; } = string.Empty;

        [JsonProperty("maximumApplicants")]
        public int MaximumApplicants { get; set; }

        public Application? Application { get; set; }
        public Workflow? Workflow { get; set; }
    }

}
