using Microsoft.Extensions.Caching.Memory;

namespace DinoPoll.Services
{
    public interface IDinoPollCache
    {
        MemoryCache Cache { get; }
    }
}