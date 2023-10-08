using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Query
{

    public class GetApplicationQuery : IRequest<Response<ApplicationDto>>
    {
        public string ProgramId { get; set; } = string.Empty;
        public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, Response<ApplicationDto>>
        {
            
            private readonly IProgramRepository _programRepository;
            private readonly IMapper _mapper;

            public GetApplicationQueryHandler(IProgramRepository programRepository, IMapper mapper)
            {
                
                _programRepository = programRepository;
                _mapper = mapper;
            }

            public async Task<Response<ApplicationDto>> Handle(GetApplicationQuery query, CancellationToken cancellationToken)
            {
                
                var program = await _programRepository.GetAsync(query.ProgramId);
                if (program != null)
                {
                    var application = program.Application;
                    var response = _mapper.Map<ApplicationDto>(application);
                    return new Response<ApplicationDto>(response);
                }
                return new Response<ApplicationDto>(ResponseMessage.RecordNotFound, false);

            }
        }
    }
}
