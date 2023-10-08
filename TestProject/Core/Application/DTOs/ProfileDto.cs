namespace TestProject.DTOs
{
    public class ProfileDto
    {
        public ProfileDto()
        {
            AdditionalQuestions = new Dictionary<string, string>();
            Education = new List<EducationDto>();
            Experience = new List<ExperienceDto>();
        }
        public List<EducationDto>? Education { get; set; }
        public List<ExperienceDto>? Experience { get; set; }

        public string? ResumeId { get; set; }
      
        public Dictionary<string, string> AdditionalQuestions { get; set; }
    }


}
