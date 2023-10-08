using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   

    public class VideoInterview
    {
        [JsonProperty("question")]
        public string Question { get; set; } = string.Empty;
        [JsonProperty("additionalInformation")]
        public string AdditionalInformation { get; set; } = string.Empty;

        [JsonProperty("maxDuration")]
        public int MaxDuration { get; set; }

        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }

    }

}
