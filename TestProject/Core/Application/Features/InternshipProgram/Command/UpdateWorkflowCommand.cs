using AutoMapper;
using MediatR;
using TestProject.DTOs;
using TestProject.Models;
using TestProject.Repository;
using TestProject.Responses;

namespace TestProject.Features.InternshipProgram.Command
{


    public class UpdateWorkflowCommand : EditWorkflowDto, IRequest<Response<InternshipProgramDto>>
    {

    }

    public class UpdateWorkflowCommandHandler : IRequestHandler<UpdateWorkflowCommand, Response<InternshipProgramDto>>
    {
      
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
       

        public UpdateWorkflowCommandHandler(IProgramRepository programRepository, IMapper mapper)
        {
            
            _programRepository = programRepository;
            _mapper = mapper;
           
        }

        public async Task<Response<InternshipProgramDto>> Handle(UpdateWorkflowCommand request, CancellationToken cancellationToken)
        {

            var program = await _programRepository.GetAsync(request.ProgramId);
            if(program != null)
            {
                var workflow = program.Workflow;

                var updatedVideoInterview = _mapper.Map<VideoInterviewDto, VideoInterview>(request.VideoInterview, workflow.VideoInterview!);
                program.Workflow!.Stage = !string.IsNullOrEmpty(request.Stage) ? request.Stage : program.Workflow.Stage;

                program.Workflow.VideoInterview = updatedVideoInterview;


                await _programRepository.UpdateAsync(request.ProgramId, program);

                var response = _mapper.Map<InternshipProgramDto>(program);
                return new Response<InternshipProgramDto>(response, ResponseMessage.UpdateSuccess);
            }
            return new Response<InternshipProgramDto>(ResponseMessage.RecordNotFound, false);
        }

    }
}
