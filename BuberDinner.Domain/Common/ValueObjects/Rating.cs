
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value {get; private set;}

    public Rating(double value)
    {
        Value = value;
    }

    public static Rating Create(double rating = 0)
    {
        return new Rating(rating);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

