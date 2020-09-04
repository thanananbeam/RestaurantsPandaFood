namespace Restaurants.API.Services.MemoryCacheServices
{
    public interface IMemoryCacheServices
    {
        object GetMemoryCache<T>(string key);
        void SetMemoryCache<T>(string key, T value);
    }
}