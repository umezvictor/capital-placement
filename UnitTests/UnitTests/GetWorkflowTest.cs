using AutoMapper;
using Moq;
using Shouldly;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;
using static TestProject.Features.InternshipProgram.Query.GetWorkflowQuery;

namespace UnitTests.UnitTests
{

    public class GetWorkflowTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly GetWorkflowQueryHandler ServiceToTest;

        public GetWorkflowTest()
        {
            ServiceToTest = new GetWorkflowQueryHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task GetWorkflow_IfRecordExists_ReturnsWorkflowDto()
        {


            // Arrange

            var videoInterview = new VideoInterview
            {
                Deadline = DateTime.Now.AddDays(4),
                Question = "What is your age?"
            };

            var videoInterviewDto = new VideoInterviewDto
            {
                Deadline = DateTime.Now.AddDays(4),
                Question = "What is your age?"
            };

            var workflow = new Workflow
            {
                Stage = "Video Interview",
                VideoInterview = videoInterview
            };

            var workflowDto = new WorkflowDto
            {
                Stage = "Video Interview",
                VideoInterview = videoInterviewDto
            };

            var request = new GetWorkflowQuery
            {
                ProgramId = "d160b71c-99d3-47df-a673-bbe210c98f67",
               
               
            };

        
             var program = new InternshipProgram
            {
                Id = "d160b71c-99d3-47df-a673-bbe210c98f67",
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
                Workflow = workflow,

            };

            var programDto = new InternshipProgramDto
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
            };

           

            _programRepoMock.Setup(x => x.GetAsync(request.ProgramId)).ReturnsAsync(program);

            _mapperMock.Setup(x => x.Map<WorkflowDto>(workflow)).Returns(workflowDto);
            


            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<WorkflowDto>();
           

        }



    }
}
