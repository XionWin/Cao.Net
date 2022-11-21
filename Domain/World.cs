using System.Numerics;

namespace Domain;
public class World
{
    public Guid Id { get; } = new Guid();
    public string? Name { get; set; }
    public string? Description { get; set; }

    public System.Collections.Generic.HashSet<Entity> Entities { get; } = new HashSet<Entity>();
}
