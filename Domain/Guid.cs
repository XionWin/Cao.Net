using System.Collections;

namespace Domain;
public class Guid
{
    public System.Collections.Generic.HashSet<Entity> Entities { get; } = new HashSet<Entity>();
    public Dictionary<string, HashList<Entity>>DimenstionTable { get; } = new Dictionary<string, HashList<Entity>>();

    public void Add(Entity entity)
    {
        this.Entities.Add(entity);
    }
}

// public static class GuidExtension
// {
//     public static (string propName, Object key) 
// }
