using System.Numerics;

namespace Domain;
public class Entity
{
    [GuidSensitive]
    public required Guid Id { get; init; }
    [GuidSensitive]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Vector2 Position { get; set; }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
