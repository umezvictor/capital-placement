using AutoMapper;
using MediatR;
using TestProject.Core.Application.Services;
using TestProject.DTOs;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Command
{


    public class UpdateApplicationCommand : EditApplicationDto, IRequest<Response<InternshipProgramDto>>
    {

    }

    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, Response<InternshipProgramDto>>
    {
      
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public UpdateApplicationCommandHandler(IProgramRepository programRepository, IMapper mapper, IFileService fileService)
        {
            
            _programRepository = programRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Response<InternshipProgramDto>> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {

            var program = await _programRepository.GetAsync(request.ProgramId);
            if(program != null)
            {

               //upload cover image
               if(request.CoverImage != null)
                {
                    if (request.CoverImage.Length > 0)
                    {
                        var uploadResponse = _fileService.UploadImage(request.CoverImage);
                        if (uploadResponse.Success)
                        {
                            var coverImageUrl = _fileService.GetImageUrl(uploadResponse.FileId);
                            program.Application.CoverImageUrl = coverImageUrl;
                            program.Application.CoverImageId = uploadResponse.FileId;

                        }


                    }
                }
               
               if(request.Profile.Resume != null)
                {
                    //upload resume
                    if (request.Profile.Resume.Length > 0)
                    {
                        var resumeId = await _fileService.UploadDocument(request.Profile.Resume);
                        if (!string.IsNullOrEmpty(resumeId))
                            program.Application.Profile.ResumeId = resumeId;
                    }

                }

                var personalInformation = program.Application.PersonalInformation;
                var profile = program.Application.Profile;

                var updatedInfo = _mapper.Map<PersonalInformationDto, PersonalInformation>(request.PersonalInformation, personalInformation!);
                var updatedProfile = _mapper.Map<EditProfileDto, Models.Profile>(request.Profile, profile!);

                program.Application.PersonalInformation = updatedInfo;
                program.Application.Profile = updatedProfile;

                await _programRepository.UpdateAsync(request.ProgramId, program);

                var response = _mapper.Map<InternshipProgramDto>(program);
                return new Response<InternshipProgramDto>(response, ResponseMessage.UpdateSuccess);
            }
            return new Response<InternshipProgramDto>(ResponseMessage.RecordNotFound, false);
        }

    }
}
