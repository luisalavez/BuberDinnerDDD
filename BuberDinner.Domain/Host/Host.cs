

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<DinnerId> _dinnerIds = new(); 

    private readonly List<MenuId> _menuIds = new();   
    public string FirstName {get;}
    public string LastName {get;}
    public Uri ProfileImage {get;}
    public AverageRating AverageRating {get;}
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public HostId HostId {get;}
    public DateTime CreatedDateTime {get;}
    public DateTime UpdatedDateTime {get;}

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        AverageRating averageRating
    ): base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId
    )
    {
        return new(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            userId,
            AverageRating.CreateNew()
        );
    }
}