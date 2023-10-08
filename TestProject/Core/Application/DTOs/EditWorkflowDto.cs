namespace TestProject.DTOs
{
    public class EditWorkflowDto
    {
        public string ProgramId { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public VideoInterviewDto? VideoInterview { get; set; }
    }
}
