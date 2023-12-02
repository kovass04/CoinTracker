﻿using CoinTracker.Models;
using CoinTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly DataServices _Services;
        private string _searchText;
        private List<Assets> _allAssets;
        private List<Assets> _filteredAssets;
        public List<Assets> Asset
        {
            get => _filteredAssets;
            set
            {
                SetProperty(ref _filteredAssets, value);
            }
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    PerformSearch();
                }
            }
        }
        private void PerformSearch()
        {
            var filteredAssets = _allAssets.Where(a => a.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            Asset = filteredAssets;
        }
        public SearchViewModel()
        {
            _Services = new DataServices();
            _ = LoadAssetsAsync();
        }

        protected async Task LoadAssetsAsync()
        {
            var assets = await _Services.GetAssetsAsync();
            _allAssets = new List<Assets>(assets.Data);
            Asset = new List<Assets>(_allAssets);
        }
    }
}
