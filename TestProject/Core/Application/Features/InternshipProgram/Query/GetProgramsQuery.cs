using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Query
{


    public class GetProgramsQuery : IRequest<Response<List<InternshipProgramDto>>>
    {
      
        public class GetProgramsQueryHandler : IRequestHandler<GetProgramsQuery, Response<List<InternshipProgramDto>>>
        {
            
            private readonly IProgramRepository _programRepository;
            private readonly IMapper _mapper;

            public GetProgramsQueryHandler(IProgramRepository programRepository, IMapper mapper)
            {
                
                _programRepository = programRepository;
                _mapper = mapper;
            }

            public async Task<Response<List<InternshipProgramDto>>> Handle(GetProgramsQuery query, CancellationToken cancellationToken)
            {
                
                var programs = await _programRepository.GetAllAsync("SELECT * FROM c");
                if (programs != null)
                {
                    var response = _mapper.Map<List<InternshipProgramDto>>(programs);
                    return new Response<List<InternshipProgramDto>>(response);
                }
                return new Response<List<InternshipProgramDto>>(ResponseMessage.RecordNotFound, false);

            }
        }
    }
}
