using AutoMapper;
using Moq;
using Shouldly;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;

namespace UnitTests.UnitTests
{

    public class UpdateWorkflowTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly UpdateWorkflowCommandHandler ServiceToTest;

        public UpdateWorkflowTest()
        {
            ServiceToTest = new UpdateWorkflowCommandHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task UpdateWorkflow_IfValidPayload_ReturnsProgramDto()
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

            var request = new UpdateWorkflowCommand
            {
                ProgramId = "d160b71c-99d3-47df-a673-bbe210c98f67",
                Stage =  "Video Interview",
                VideoInterview = videoInterviewDto
               
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

            _mapperMock.Setup(x => x.Map<VideoInterviewDto, VideoInterview>(request.VideoInterview, videoInterview!)).Returns(videoInterview);
            _programRepoMock.Setup(x => x.UpdateAsync(request.ProgramId, program));
            _mapperMock.Setup(x => x.Map<InternshipProgramDto>(program)).Returns(programDto);



            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<InternshipProgramDto>();
            result.Message.ShouldBe(ResponseMessage.UpdateSuccess);


        }



    }
}
