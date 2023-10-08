using FluentValidation;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class GetWorkflowQueryValidator : AbstractValidator<GetWorkflowQuery>
    {
        public GetWorkflowQueryValidator()
        {
           
            RuleFor(p => p.ProgramId).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
