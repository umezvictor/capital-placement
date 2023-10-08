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

    public class UpdateProgramTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly UpdateProgramCommandHandler ServiceToTest;

        public UpdateProgramTest()
        {
            ServiceToTest = new UpdateProgramCommandHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task UpdateProgram_ValidPayload_ReturnsProgramDto()
        {

            // Arrange
            var request = new UpdateProgramCommand
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
                Id = "d160b71c-99d3-47df-a673-bbe210c98f67"
            };


            var program = new InternshipProgram
            {
                Id = "d160b71c-99d3-47df-a673-bbe210c98f67",
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",

            };

            var programDto = new InternshipProgramDto
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
            };

            _programRepoMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(program);
            _mapperMock.Setup(x => x.Map<InternshipProgram>(request)).Returns(program);
            _programRepoMock.Setup(x => x.UpdateAsync(request.Id, program));
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
