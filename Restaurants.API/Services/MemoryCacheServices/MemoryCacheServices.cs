using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.API.Services.MemoryCacheServices
{
    public class MemoryCacheServices : IMemoryCacheServices
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public MemoryCacheServices(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        public object GetMemoryCache<T>(string key)
        {
            object result = _cache.Get(key.ToLower());
            return result;
        }

        public void SetMemoryCache<T>(string key, T value)
        {
            _cache.GetOrCreate(key.ToLower(), entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(double.Parse(_configuration["CacheTime"]));
                return value;
            });
        }
    }
}
