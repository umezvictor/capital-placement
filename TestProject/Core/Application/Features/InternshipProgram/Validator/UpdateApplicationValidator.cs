using FluentValidation;
using TestProject.Features.InternshipProgram.Command;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class UpdateApplicationValidator : AbstractValidator<UpdateApplicationCommand>
    {
        public UpdateApplicationValidator()
        {
           
            RuleFor(p => p.ProgramId).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
