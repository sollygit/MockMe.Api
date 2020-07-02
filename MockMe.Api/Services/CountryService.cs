using Microsoft.Extensions.Logging;
using MockMe.Common;
using MockMe.Model;
using System;
using System.Collections.Generic;
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

        public CountryService(ILogger<CountryService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var countries = new List<Country>();

            try
            {
                countries = MockUtil.Countries(5);
            }
            catch (Exception ex)
            {
                _logger.LogError("CountryService GetAll Error", ex);
            }

            return await Task.FromResult(countries);
        }
    }
}
