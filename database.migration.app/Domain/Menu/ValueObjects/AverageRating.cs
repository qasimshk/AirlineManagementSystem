using airline.management.sharedkernal.Common;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        private AverageRating() { }
        
        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }

        public double Value { get; private set; }

        public int NumRatings { get; private set; }

        public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
        {
            return new AverageRating(rating, numRatings);
        }

        public void AddNewRating(Rating rating)
        {
            Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        }

        internal void RemoveRating(Rating rating)
        {
            Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public class Rating
    {
        public double Value { get; private set; }
    }
}
