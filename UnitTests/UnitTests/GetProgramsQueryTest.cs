using AutoMapper;
using Moq;
using Shouldly;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Query;
using TestProject.Models;
using TestProject.Repository;
using static TestProject.Features.InternshipProgram.Query.GetProgramsQuery;

namespace UnitTests.UnitTests
{

    public class GetProgramsQueryTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly GetProgramsQueryHandler ServiceToTest;

        public GetProgramsQueryTest()
        {
            ServiceToTest = new GetProgramsQueryHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task GetPrograms_IfRecordExists_ReturnsListOfProgramDto()
        {

            // Arrange
            var request = new GetProgramsQuery();
                  

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

            var programDtoList = new List<InternshipProgramDto>();
            programDtoList.Add(programDto);

            var programList = new List<InternshipProgram>();
            programList.Add(program);


            _programRepoMock.Setup(x => x.GetAllAsync("SELECT * FROM c")).ReturnsAsync(programList);
            _mapperMock.Setup(x => x.Map<List<InternshipProgramDto>>(programList)).Returns(programDtoList);
          


            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<List<InternshipProgramDto>>();
           

        }



    }
}
