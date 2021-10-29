using FluentValidation;

namespace airline.management.application.Commands.SubmitOrder
{
    public class SubmitOrderCommandValidator : AbstractValidator<SubmitOrderCommand>
    {
        public SubmitOrderCommandValidator()
        {
            RuleFor(x => x.FlightNumber)
               .Cascade(CascadeMode.Stop)
               .Length(5, 6).WithMessage("Please provide a valid flight number")
               .NotEmpty().WithMessage("Please provide flight number");

            RuleFor(x => x.DepartureDate)
               .Cascade(CascadeMode.Stop)               
               .NotEmpty().WithMessage("Please provide a valid departure date");

            RuleFor(x => x.FirstName)
               .Cascade(CascadeMode.Stop)
               .Length(3, 10).WithMessage("First name can be minimum two and maximum 10 charactors long")
               .NotEmpty().WithMessage("Please provide first name");

            RuleFor(x => x.LastName)
               .Cascade(CascadeMode.Stop)
               .Length(3, 10).WithMessage("Last name can be minimum two and maximum 10 charactors long")
               .NotEmpty().WithMessage("Please provide last name");

            RuleFor(x => x.EmailAddress)
               .Cascade(CascadeMode.Stop)
               .EmailAddress().WithMessage("Please provide a valid email address")
               .NotEmpty().WithMessage("Email address is required");
        }
    }
}
