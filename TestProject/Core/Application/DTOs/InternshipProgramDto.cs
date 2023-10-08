namespace TestProject.DTOs
{


    public class InternshipProgramDto
    {
        public InternshipProgramDto()
        {
            Id = Guid.NewGuid().ToString();
            Skills = new List<string>();
            Benefits = new List<string>();
            Criteria = new List<string>();
        }

        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
      
        public string Description { get; set; } = string.Empty;
        public List<string> Skills { get; set; }
        public List<string> Benefits { get; set; }
        public List<string> Criteria { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public int Duration { get; set; }
        public string ProgramLocation { get; set; } = string.Empty;
        public string MinimumQualification { get; set; } = string.Empty;
        public int MaximumApplicants { get; set; }
        public ApplicationDto? Application { get; set; }
        public WorkflowDto? Workflow { get; set; }

      
    }
}
