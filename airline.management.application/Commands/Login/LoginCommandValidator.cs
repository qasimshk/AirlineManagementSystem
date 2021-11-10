using FluentValidation;

namespace airline.management.application.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
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
