using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;
using DynamicFlow.API.Core.Service.Interfaces;

namespace DynamicFlow.API.Core.Service
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public bool TryGet<T>(string cacheKey, out T value)
        {
            value = default!;
            var cachedData = _distributedCache.Get(cacheKey);
            if (cachedData != null)
            {
                var serializedCachedData = Encoding.UTF8.GetString(cachedData);
                if (serializedCachedData is not null)
                {
                    var result = JsonSerializer.Deserialize<T>(serializedCachedData);
                    value = result ?? throw new NullReferenceException();
                }
            }
            return value != null;
        }
        public T Set<T>(string cacheKey, T value, int AbsoluteExpiration = 10, int SlidingExpiration = 5)
        {
            var serializedData = JsonSerializer.Serialize(value);
            var byteData = Encoding.UTF8.GetBytes(serializedData);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(AbsoluteExpiration))
                .SetSlidingExpiration(TimeSpan.FromMinutes(SlidingExpiration));
            _distributedCache.Set(cacheKey, byteData, options);
            return value;
        }
        public void Remove(string cacheKey)
        {
            _distributedCache.Remove(cacheKey);
        }
    }
}
