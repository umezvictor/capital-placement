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

    public class CreateProgramTests
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly CreateProgramCommandHandler ServiceToTest;

        public CreateProgramTests()
        {
            ServiceToTest = new CreateProgramCommandHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task CreateProgram_ValidPayload_ReturnsProgramDto()
        {

            // Arrange
            var request = new CreateProgramCommand
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
            };


            var program = new InternshipProgram
            {
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


            _mapperMock.Setup(x => x.Map<InternshipProgram>(request)).Returns(program);
            _programRepoMock.Setup(x => x.AddAsync(It.IsAny<InternshipProgram>()));
            _mapperMock.Setup(x => x.Map<InternshipProgramDto>(program)).Returns(programDto);



            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<InternshipProgramDto>();
            result.Message.ShouldBe(ResponseMessage.RecordCreated);


        }



    }
}
