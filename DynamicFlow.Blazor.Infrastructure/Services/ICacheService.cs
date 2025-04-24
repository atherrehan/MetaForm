namespace DynamicFlow.Blazor.Infrastructure.Services
{
    public interface ICacheService
    {
        bool Get<T>(string cacheKey, out T value);

        T Set<T>(string cacheKey, T value, int AbsoluteExpiration = 10, int SlidingExpiration = 5);

        void Remove(string cacheKey);
    }
}
