namespace TestProject.DTOs
{


    public class EditApplicationDto
    {
        public string ProgramId { get; set; } = string.Empty;
        public IFormFile? CoverImage { get; set; } 
        public PersonalInformationDto? PersonalInformation { get; set; }
        public EditProfileDto? Profile { get; set; }
    }
}
