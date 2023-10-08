using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using TestProject.Core.Application.Responses;
using TestProject.Core.Application.Services;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;

namespace UnitTests.UnitTests
{

    public class UpdateApplicationTest
    {
        private readonly Mock<IProgramRepository> _programRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IFileService> _fileServiceMock = new();
        private readonly UpdateApplicationCommandHandler ServiceToTest;
        public IFormFile? File;
        public UpdateApplicationTest()
        {
            ServiceToTest = new UpdateApplicationCommandHandler(_programRepoMock.Object, _mapperMock.Object, _fileServiceMock.Object);

        }


        [Fact]
        public async Task UpdateApplication_IfValidPayload_ReturnsProgramDto()
        {
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

            var editProfile = new TestProject.Models.Profile
            {
                Education = educationList,
                Experience = experienceList

            };

            // Arrange
            var request = new UpdateApplicationCommand
            {
                ProgramId = "d160b71c-99d3-47df-a673-bbe210c98f67",
                
                PersonalInformation = personalInfoDto,
                Profile = editProfileDto,
               
            };
                   

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
            var program = new InternshipProgram
            {
                ApplicationClose = DateTime.Now.AddDays(4),
                ProgramStart = DateTime.Now,
                Description = "Program description",
                ProgramLocation = "London",
                Summary = "Program summary",
                Application = application
                
            };

            var imageUrl = "http://imageurl";

            var uploadResponse = new FileResponse { FileId = "13232323", Success = true };

            _programRepoMock.Setup(x => x.GetAsync(request.ProgramId)).ReturnsAsync(program);
           
            _fileServiceMock.Setup(x => x.UploadImage(File)).Returns(uploadResponse);
            _fileServiceMock.Setup(x => x.GetImageUrl(uploadResponse.FileId));
            _fileServiceMock.Setup(x => x.UploadDocument(File));

            _mapperMock.Setup(x => x.Map<PersonalInformationDto, PersonalInformation>(request.PersonalInformation, program.Application.PersonalInformation));
            _mapperMock.Setup(x => x.Map<EditProfileDto, TestProject.Models.Profile>(request.Profile, program.Application.Profile));

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
