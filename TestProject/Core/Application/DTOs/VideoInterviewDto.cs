using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DTOs
{
    public class VideoInterviewDto
    {

        public string Question { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
        public int MaxDuration { get; set; }
        public DateTime Deadline { get; set; }
    }
}
