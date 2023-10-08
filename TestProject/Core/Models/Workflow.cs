using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   

    public class Workflow
    {
        [JsonProperty("stage")]
        public string Stage { get; set; } = string.Empty;

        [JsonProperty("videoInterview")]
        public VideoInterview? VideoInterview { get; set; }


    }

}
