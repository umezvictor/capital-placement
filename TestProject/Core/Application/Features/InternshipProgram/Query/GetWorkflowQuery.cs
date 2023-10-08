using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Query
{

    public class GetWorkflowQuery : IRequest<Response<WorkflowDto>>
    {
        public string ProgramId { get; set; } = string.Empty;
        public class GetWorkflowQueryHandler : IRequestHandler<GetWorkflowQuery, Response<WorkflowDto>>
        {
            
            private readonly IProgramRepository _programRepository;
            private readonly IMapper _mapper;

            public GetWorkflowQueryHandler(IProgramRepository programRepository, IMapper mapper)
            {
                
                _programRepository = programRepository;
                _mapper = mapper;
            }

            public async Task<Response<WorkflowDto>> Handle(GetWorkflowQuery query, CancellationToken cancellationToken)
            {
                
                var program = await _programRepository.GetAsync(query.ProgramId);
                if (program != null)
                {
                    var workflow = program.Workflow;
                    var response = _mapper.Map<WorkflowDto>(workflow);
                    return new Response<WorkflowDto>(response);
                }
                return new Response<WorkflowDto>(ResponseMessage.RecordNotFound, false);

            }
        }
    }
}
