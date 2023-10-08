using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
   


    public class Application
    {
        [JsonProperty("coverImageId")]
        public string CoverImageId { get; set; } = string.Empty;

        [JsonProperty("coverImageUrl")]
        public string CoverImageUrl { get; set; } = string.Empty;

        [JsonProperty("personalInformation")]
        public PersonalInformation? PersonalInformation { get; set; }

        [JsonProperty("profile")]
        public Profile? Profile { get; set; }
    }

}
