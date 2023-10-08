using FluentValidation;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class GetProgramQueryValidator : AbstractValidator<GetProgramQuery>
    {
        public GetProgramQueryValidator()
        {
           
            RuleFor(p => p.Id).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
