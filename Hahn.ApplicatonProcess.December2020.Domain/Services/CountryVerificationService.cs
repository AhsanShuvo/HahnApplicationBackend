using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public class CountryVerificationService : ICountryVerificationService
    {
        private readonly HttpClient _httpClient;

        public CountryVerificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsValidCountry(string country)
        {
            var request = string.Format("https://restcountries.eu/rest/v2/name/{0}?fullText=true", country);
            var res = await _httpClient.GetAsync(request);
            if (res.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
