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

namespace UnitTests.UnitTests
{

    public class GetApplicationQueryTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly GetApplicationQueryHandler ServiceToTest;

        public GetApplicationQueryTest()
        {
            ServiceToTest = new GetApplicationQueryHandler(_programRepoMock.Object, _mapperMock.Object);

        }


        [Fact]
        public async Task GetApplication_IfRecordExists_ReturnsApplicationDto()
        {

            // Arrange
            var request = new GetApplicationQuery
            {
               
                ProgramId = "d160b71c-99d3-47df-a673-bbe210c98f67"
            };

            var personalInfoDto = new PersonalInformationDto
            {
                FirstName = "Chibuzor",
                LastName = "Umezuruike",
                Email = "victorblaze2010@gmail.com",

            };
            var personalInfo = new PersonalInformation
            {
                FirstName = "Chibuzor",
                LastName = "Umezuruike",
                Email = "victorblaze2010@gmail.com",

            };

            var educationDto = new EducationDto
            {
                School = "London University",
                Location = "London",
                Course = "Computer",

            };

            var education = new Education
            {
                School = "London University",
                Location = "London",
                Course = "Computer",

            };

            var educationDtoList = new List<EducationDto>();
            educationDtoList.Add(educationDto);

            var educationList = new List<Education>();
            educationList.Add(education);


            var experienceDto = new ExperienceDto
            {
                Company = "Capital Placement",
                Location = "London",
                Title = "Software Developer",

            };

            var experience = new Experience
            {
                Company = "Capital Placement",
                Location = "London",
                Title = "Software Developer",

            };

            var experienceDtoList = new List<ExperienceDto>();
            experienceDtoList.Add(experienceDto);

            var experienceList = new List<Experience>();
            experienceList.Add(experience);


            var editProfileDto = new EditProfileDto
            {
                Education = educationDtoList,
                Experience = experienceDtoList

            };

            var profileDto = new ProfileDto
            {
                Education = educationDtoList,
                Experience = experienceDtoList

            };

            var editProfile = new TestProject.Models.Profile
            {
                Education = educationList,
                Experience = experienceList

            };

            // Arrange
           

            var programDto = new InternshipProgramDto
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
            };


            var application = new Application
            {
                PersonalInformation = personalInfo,
                Profile = editProfile,
                CoverImageId = "1213232323",
                CoverImageUrl = "http://imageurl"
            };

            var applicationDto = new ApplicationDto
            {
                PersonalInformation = personalInfoDto,
                Profile = profileDto,
                CoverImageId = "1213232323",
                CoverImageUrl = "http://imageurl"
            };
            var program = new InternshipProgram
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
                Application = application

            };

            _programRepoMock.Setup(x => x.GetAsync(request.ProgramId)).ReturnsAsync(program);
            _mapperMock.Setup(x => x.Map<ApplicationDto>(application)).Returns(applicationDto);
          


            // Act
            var result = await ServiceToTest.Handle(request, CancellationToken.None);

            //Assert

            result.ShouldNotBeNull();
            result.Succeeded.ShouldBeTrue();
            result.Data.ShouldBeOfType<ApplicationDto>();
           

        }



    }
}
