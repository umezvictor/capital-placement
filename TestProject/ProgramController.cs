using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.DTOs;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;
using TestProject.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject
{
    [Route("[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]
        public async Task<IActionResult> Create([FromBody] CreateProgramCommand request)
        {
            var response = await _mediator!.Send(request);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Response<List<InternshipProgramDto>>))]
        public async Task<IActionResult> List()
        {
            var response = await _mediator!.Send(new GetProgramsQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _mediator!.Send(new GetProgramQuery { Id = id});
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

   
       

        
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateProgramCommand request)
        {
            var response = await _mediator!.Send(request);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }


       
        [HttpGet("{id}/application")]
        [ProducesResponseType(200, Type = typeof(Response<ApplicationDto>))]
        public async Task<IActionResult> GetApplication(string id)
        {
            var response = await _mediator!.Send(new GetApplicationQuery { ProgramId = id });
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }


        
        [HttpPut("application")]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]
        public async Task<IActionResult> EditApplication([FromForm] UpdateApplicationCommand request)
        {
            var response = await _mediator!.Send(request);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

     
        [HttpGet("{id}/workflow")]
        [ProducesResponseType(200, Type = typeof(Response<WorkflowDto>))]
        public async Task<IActionResult> GetWorkflowAsync(string id)
        {
            var response = await _mediator!.Send(new GetWorkflowQuery { ProgramId = id });
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }


        [HttpPut("workflow")]
        [ProducesResponseType(200, Type = typeof(Response<InternshipProgramDto>))]
        public async Task<IActionResult> EditWorkflow([FromBody] UpdateWorkflowCommand request)
        {
            var response = await _mediator!.Send(request);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
