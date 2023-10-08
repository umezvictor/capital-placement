using AutoMapper;
using MediatR;
using TestProject.Core.Application.Services;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Query
{


    public class GetProgramQuery : IRequest<Response<InternshipProgramDto>>
    {
        public string Id { get; set; } = string.Empty;
        public class GetProgramQueryHandler : IRequestHandler<GetProgramQuery, Response<InternshipProgramDto>>
        {
            
            private readonly IProgramRepository _programRepository;
            private readonly IMapper _mapper;
  

            public GetProgramQueryHandler(IProgramRepository programRepository, IMapper mapper)
            {
                
                _programRepository = programRepository;
                _mapper = mapper;
               
            }

            public async Task<Response<InternshipProgramDto>> Handle(GetProgramQuery query, CancellationToken cancellationToken)
            {
               
                var program = await _programRepository.GetAsync(query.Id);
                if (program != null)
                {
                    var response = _mapper.Map<InternshipProgramDto>(program);                                     
                    return new Response<InternshipProgramDto>(response);
                }
                return new Response<InternshipProgramDto>(ResponseMessage.RecordNotFound, false);

            }
        }
    }
}
