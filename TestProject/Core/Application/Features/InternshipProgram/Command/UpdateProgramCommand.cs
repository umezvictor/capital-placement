using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Command
{


    public class UpdateProgramCommand : InternshipProgramDto, IRequest<Response<InternshipProgramDto>>
    {

    }

    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, Response<InternshipProgramDto>>
    {
      
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
       

        public UpdateProgramCommandHandler(IProgramRepository programRepository, IMapper mapper)
        {
            
            _programRepository = programRepository;
            _mapper = mapper;
           
        }

        public async Task<Response<InternshipProgramDto>> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var existingProgram = await _programRepository.GetAsync(request.Id);
            if (existingProgram != null)
            {
                var program = _mapper.Map<Models.InternshipProgram>(request);
                await _programRepository.UpdateAsync(request.Id, program);
                var response = _mapper.Map<InternshipProgramDto>(program);
                return new Response<InternshipProgramDto>(response, ResponseMessage.UpdateSuccess);
            }
            return new Response<InternshipProgramDto>(ResponseMessage.RecordNotFound, false);
        }

    }
}
