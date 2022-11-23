using System.Numerics;

namespace Domain;
public class Entity
{
    [WorldSensitive]
    public required Guid Id { get; init; }
    [WorldSensitive]
    public string? Name { get; set; }
    public string? Description { get; set; }
    [WorldSensitive]
    public Vector2 Position { get; set; }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
