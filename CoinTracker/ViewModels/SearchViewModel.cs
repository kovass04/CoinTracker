using CoinTracker.Models;
using CoinTracker.Services;
using CoinTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace CoinTracker.ViewModels
{
    /// <summary>
    /// ViewModel for managing asset search functionality.
    /// </summary>
    public class SearchViewModel : BaseViewModel
    {
        private readonly DataServices _services;
        private string _searchText;
        private List<Assets> _allAssets;
        private List<Assets> _filteredAssets;
        private Assets _selectedAsset;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchViewModel"/> class.
        /// </summary>
        public SearchViewModel()
        {
            _services = new DataServices();
            _ = LoadAssetsAsync();
        }

        /// <summary>
        /// Gets or sets the filtered list of assets based on the search text.
        /// </summary>
        public List<Assets> Asset
        {
            get => _filteredAssets;
            set
            {
                SetProperty(ref _filteredAssets, value);
            }
        }

        /// <summary>
        /// Gets or sets the search text for filtering assets.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the selected asset.
        /// </summary>
        public Assets SelectedAsset
        {
            get { return _selectedAsset; }
            set
            {
                if (_selectedAsset != value)
                {
                    _selectedAsset = value;
                    OnPropertyChanged(nameof(SelectedAsset));

                    HandleSelectedAsset();
                }
            }
        }

        /// <summary>
        /// Loads all assets from the data service.
        /// </summary>
        /// <returns>An asynchronous task.</returns>
        protected async Task LoadAssetsAsync()
        {
            var assets = await _services.GetAssetsAsync();
            _allAssets = new List<Assets>(assets.Data);
            Asset = new List<Assets>(_allAssets);
        }

        /// <summary>
        /// Filters the list of assets based on the search text.
        /// </summary>
        private void PerformSearch()
        {
            Asset = _allAssets
            .Where(a => a.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }

        /// <summary>
        /// Navigates to the selected asset page.
        /// </summary>
        private void HandleSelectedAsset()
        {
            if (Window.Current?.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(SelectedItemPage), SelectedAsset?.Id.ToString());
            }
        }
    }
}
