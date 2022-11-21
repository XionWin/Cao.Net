using System.Collections;
using System.Runtime.CompilerServices;


namespace Domain;
public class HashList<T>
{
    private Hashtable _items = new Hashtable();
    
    public Result Add(object key, T value, [CallerArgumentExpression("key")] string keyCaller = "") =>
        key is not null ?
                this._items.Contains(key) ?
                    this._items[key] is HashSet<T> itemSet ?
                        itemSet.Add(value) ?
                            Result.OK() :
                            throw new Exception($"ItemSet type error") :
                        throw new Exception($"ItemSet type error") :
                    Result.OK().With(_ => this._items.Add(key, new HashSet<T>().With(x => x.Add(value)))) :
                throw new Exception($"Key {keyCaller} can't be null");

    public Result Remove(object key, [CallerArgumentExpression("key")] string keyCaller = "") =>
        key is not null ?
            this._items.Contains(key) ?
                Result.OK().With(_ => this._items.Remove(key)) :
                Result.OK() :
            throw new Exception($"Key {keyCaller} can't be null");

    public Result Remove(object key, T Value, [CallerArgumentExpression("key")] string keyCaller = "") =>
        key is not null ?
            this._items.Contains(key) ?
                this._items[key] is HashSet<T> itemSet && itemSet.Any() ?
                    itemSet.Remove(Value) ?
                        Result.OK() :
                        throw new Exception($"Remove value error") :
                    throw new Exception($"Itemset not found or empty") :
                throw new Exception($"The vlaue not found") :
            throw new Exception($"Key {keyCaller} can't be null");
}

