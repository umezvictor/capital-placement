using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Models;

namespace TestProject.Mappings
{
    public class ProgramProfile : AutoMapper.Profile
    {
        public ProgramProfile()
        {
            
                 CreateMap<CreateProgramCommand, Models.InternshipProgram>()
               .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InternshipProgramDto, InternshipProgram>()
               .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ApplicationDto, Models.Application>()
                .ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PersonalInformationDto, PersonalInformation>()
                .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProfileDto, Profile>()
                .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EditProfileDto, Profile>()
                .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EducationDto, Education>()
               .ReverseMap()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ExperienceDto, Experience>()
               .ReverseMap()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<WorkflowDto, Workflow>()
                .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<VideoInterviewDto, VideoInterview>()
                .ReverseMap()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
