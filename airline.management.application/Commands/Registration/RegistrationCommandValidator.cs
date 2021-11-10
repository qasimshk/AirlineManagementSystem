using FluentValidation;

namespace airline.management.application.Commands.Registration
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        public RegistrationCommandValidator()
        {
            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)               
               .NotEmpty().WithMessage("Please provide a valid email address");

            RuleFor(x => x.Password)
               .Cascade(CascadeMode.Stop)               
               .NotEmpty().WithMessage("Please provide a valid password");
        }
    }
}
