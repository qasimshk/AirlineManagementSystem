using FluentValidation;

namespace airline.management.application.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.Token)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Please provide a valid token");

            RuleFor(x => x.RefreshToken)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Please provide a valid refresh token");
        }
    }
}
