using FluentValidation;
using TestProject.Features.InternshipProgram.Command;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class UpdateProgramValidator : AbstractValidator<UpdateProgramCommand>
    {
        public UpdateProgramValidator()
        {
           
            RuleFor(p => p.Id).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
