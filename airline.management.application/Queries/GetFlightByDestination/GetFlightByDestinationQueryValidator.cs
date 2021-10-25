using FluentValidation;

namespace airline.management.application.Queries.GetFlightByDestination
{
    public class GetFlightByDestinationQueryValidator : AbstractValidator<GetFlightByDestinationQuery>
    {
        public GetFlightByDestinationQueryValidator()
        {
            RuleFor(x => x.Departure)                
               .Cascade(CascadeMode.Stop)
               .Length(3, 3).WithMessage("Invalid country ISO")
               .NotEmpty().WithMessage("Please provide departure country ISO");

            RuleFor(x => x.Arrival)
               .Cascade(CascadeMode.Stop)
               .Length(3, 3).WithMessage("Invalid country ISO")
               .NotEmpty().WithMessage("Please provide arrival country ISO");
        }
    }
}
