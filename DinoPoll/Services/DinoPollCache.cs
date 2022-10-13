using Microsoft.Extensions.Caching.Memory;

namespace DinoPoll.Services
{
    public class DinoPollCache : IDinoPollCache
    {
        public MemoryCache Cache { get; } = new MemoryCache(
            new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
    }
}
