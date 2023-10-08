using Newtonsoft.Json;

namespace TestProject.DTOs
{
    public class ApplicationDto
    {

      
        public string CoverImageUrl { get; set; } = string.Empty;
        public string CoverImageId { get; set; } = string.Empty;
        public PersonalInformationDto? PersonalInformation { get; set; }
        public ProfileDto? Profile { get; set; }
    }
}
