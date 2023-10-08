namespace TestProject.DTOs
{
    public class EditProfileDto
    {
        public EditProfileDto()
        {
            AdditionalQuestions = new Dictionary<string, string>();
            Education = new List<EducationDto>();
            Experience = new List<ExperienceDto>();
        }
        public List<EducationDto>? Education { get; set; }
        public List<ExperienceDto>? Experience { get; set; }

        public IFormFile? Resume { get; set; }
      
        public Dictionary<string, string> AdditionalQuestions { get; set; }
    }


}
