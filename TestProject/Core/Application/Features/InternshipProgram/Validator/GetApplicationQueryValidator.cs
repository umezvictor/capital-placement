using FluentValidation;
using TestProject.Features.InternshipProgram.Command;
using TestProject.Features.InternshipProgram.Query;

namespace TestProject.Core.Application.Features.InternshipProgram.Validator
{
   

    public class GetApplicationQueryValidator : AbstractValidator<GetApplicationQuery>
    {
        public GetApplicationQueryValidator()
        {
           
            RuleFor(p => p.ProgramId).NotEmpty()
                 .NotNull();
           
            
        }

    }
}
