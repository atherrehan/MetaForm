namespace DynamicFlow.API.Core.Service.Interfaces
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);

        T Set<T>(string cacheKey, T value, int AbsoluteExpiration = 10, int SlidingExpiration = 5);

        void Remove(string cacheKey);
    }
}
