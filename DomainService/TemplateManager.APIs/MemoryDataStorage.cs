using System.Collections.Concurrent;

public interface IDataStorage
{
    void Save(string id, object data);
    object Get(string id);
}

public class MemoryDataStorage : IDataStorage
{
    private readonly ConcurrentDictionary<string, object> _storage = new();

    public void Save(string id, object data)
    {
        _storage.TryAdd(id, data);
    }

    public object Get(string id)
    {
        return _storage.TryGetValue(id, out var data) ? data : null;
    }
}