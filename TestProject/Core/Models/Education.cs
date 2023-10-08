using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Education
    {
        [JsonProperty("school")]
        public string School { get; set; } = string.Empty;
        [JsonProperty("degree")]
        public string Degree { get; set; } = string.Empty;

        [JsonProperty("course")]
        public string Course { get; set; } = string.Empty;

        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }


    }

}

