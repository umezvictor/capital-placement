using AutoMapper;
using Moq;
using Shouldly;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;
using static TestProject.Features.InternshipProgram.Query.GetApplicationQuery;
using static TestProject.Features.InternshipProgram.Query.GetProgramQuery;

namespace UnitTests.UnitTests
{

    public class GetProgramQueryTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly GetProgramQueryHandler ServiceToTest;

        public GetProgramQueryTest()
        {
            ServiceToTest = new GetProgramQueryHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task GetProgram_IfRecordExists_ReturnsProgramDto()
        {

            // Arrange
            var request = new GetProgramQuery
            {
               
                Id = "d160b71c-99d3-47df-a673-bbe210c98f67"
            };          

            var programDto = new InternshipProgramDto
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

            _programRepoMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(program);
            _mapperMock.Setup(x => x.Map<InternshipProgramDto>(program)).Returns(programDto);
          


            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<InternshipProgramDto>();
           

        }



    }
}
