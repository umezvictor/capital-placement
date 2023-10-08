using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Command
{


    public class CreateProgramCommand : CreateInternshipProgramDto, IRequest<Response<InternshipProgramDto>>
    {

    }

    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, Response<InternshipProgramDto>>
    {
      
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
       

        public CreateProgramCommandHandler(IProgramRepository programRepository, IMapper mapper)
        {
            
            _programRepository = programRepository;
            _mapper = mapper;
           
        }

        public async Task<Response<InternshipProgramDto>> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {

            var program = _mapper.Map<Models.InternshipProgram>(request);
            await _programRepository.AddAsync(program);
            var response = _mapper.Map<InternshipProgramDto>(program);
            return new Response<InternshipProgramDto>(response, ResponseMessage.RecordCreated);
        }

    }
}
