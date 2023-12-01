﻿using CoinTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Services
{
    public class DataServices
    {
        private readonly HttpClient _httpClient;

        public DataServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }

        /*public async Task<AssetModel> GetAssetsAsync()
        {
            var response = await _httpClient.GetAsync("assets");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AssetModel>(content);
        }*/
        public async Task<AssetModel> GetAssetsAsync()
        {
            using (var response = await _httpClient.GetAsync("assets"))
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetModel>(content);
            }
        }
    }
}
