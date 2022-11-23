using System.Numerics;
using System.Reflection;

namespace Domain;
public class World
{
    public System.Collections.Generic.HashSet<Entity> Entities { get; } = new HashSet<Entity>();
    public Dictionary<string, HashList<Entity>> DimenstionTable { get; } = new Dictionary<string, HashList<Entity>>();

    private static Dictionary<Type, IEnumerable<PropertyInfo>> PROPERTIES_CACHE = new Dictionary<Type, IEnumerable<PropertyInfo>>();
    public void Add(Entity entity)
    {
        this.Entities.Add(entity);

        var type = entity.GetType();
        var sensitivedProps = PROPERTIES_CACHE.ContainsKey(type) ? 
            PROPERTIES_CACHE[type] :
            type.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(WorldSensitiveAttribute))) is var filtered && filtered.Any() ?
                filtered.With(x => PROPERTIES_CACHE.Add(type, x)) :
                filtered;
        
        foreach (var prop in sensitivedProps)
        {
            if (prop.GetValue(entity) is object value)
            {
                var list = DimenstionTable.ContainsKey(prop.Name) ? 
                DimenstionTable[prop.Name] :
                new HashList<Entity>().With(x => DimenstionTable.Add(prop.Name, x));

                list[value] = entity;
            }

        }
    }

}
