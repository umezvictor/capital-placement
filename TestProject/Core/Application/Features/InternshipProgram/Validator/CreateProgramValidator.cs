using FluentValidation;
using TestProject.Features.InternshipProgram.Command;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class CreateProgramValidator : AbstractValidator<CreateProgramCommand>
    {
        public CreateProgramValidator()
        {
           
            RuleFor(p => p.Title).NotEmpty()
                 .NotNull();
            RuleFor(p => p.Description).NotEmpty()
                 .NotNull();
            


        }

    }
}
