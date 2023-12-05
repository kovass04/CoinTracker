using CoinTracker.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinTracker.Services
{
    public class DataServices
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServices"/> class.
        /// </summary>
        public DataServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(uriString: $"https://api.coincap.io/v2/");
        }

        /// <summary>
        /// Retrieves a list of assets asynchronously.
        /// </summary>
        /// <returns> An asynchronous operation that returns an <see cref="AssetData"/> containing information about assets.</returns>
        public async Task<AssetData> GetAssetsAsync()
        {
            using (var response = await _httpClient.GetAsync("assets"))
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetData>(content);
            }
        }

        /// <summary>
        /// Retrieves information about a specific asset asynchronously.
        /// </summary>
        /// <param name="Id">The identifier of the asset.</param>
        /// <returns>An asynchronous operation that returns an <see cref="AssetDataId"/> containing detailed information about the specified asset.</returns>
        public async Task<AssetDataId> GetAssetsIdAsync(string id)
        {
            using (var response = await _httpClient.GetAsync($"assets/{id}"))
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetDataId>(content);
            }
        }
    }
}
