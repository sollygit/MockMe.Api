using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MockMe.Common;
using MockMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockMe.Api.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAll();
    }

    public class CountryService : ICountryService
    {
        private readonly ILogger<CountryService> _logger;
        private readonly IMemoryCache _cache;

        public CountryService(ILogger<CountryService> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            // Cache Countries for 24hrs due to high page load
            return await _cache.GetOrCreateAsync("Countries", async e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
                });
                
                try
                {
                    var countries = await Task.FromResult(MockUtil.Countries(5));
                    return countries.OrderBy(c => c.CountryName);
                }
                catch (Exception ex)
                {
                    _logger.LogError("CountryService GetAll Error", ex);
                }
                
                return Enumerable.Empty<Country>();
            });
        }
    }
}
