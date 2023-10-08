using FluentValidation;
using TestProject.Features.InternshipProgram.Command;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class UpdateWorkflowValidator : AbstractValidator<UpdateWorkflowCommand>
    {
        public UpdateWorkflowValidator()
        {
           
            RuleFor(p => p.ProgramId).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
