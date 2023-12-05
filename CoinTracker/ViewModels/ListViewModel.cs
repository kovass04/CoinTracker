using CoinTracker.Models;
using CoinTracker.Services;
using CoinTracker.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CoinTracker.ViewModels
{
    /// <summary>
    /// ViewModel for managing the list of assets.
    /// </summary>
    public class ListViewModel : BaseViewModel
    {
        private readonly DataServices _services;
        private List<Assets> _assets;
        private Assets _selectedAsset;
        private string _selectedSortOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewModel"/> class.
        /// </summary>
        public ListViewModel()
        {
            _services = new DataServices();
            _ = LoadAssetsAsync();

            SortOptions = new ObservableCollection<string>
        {
            "Sort by Rank",
            "Sort by Name",
            "Sort by Highest price",
            "Sort by Lowest price"
        };

        }

        /// <summary>
        /// Gets or sets the list of assets.
        /// </summary>
        public List<Assets> Asset
        {
            get => _assets;
            set
            {
                SetProperty(ref _assets, value);
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
        /// Gets or sets the selected sort option.
        /// </summary>
        public string SelectedSortOption
        {
            get { return _selectedSortOption; }
            set
            {
                if (_selectedSortOption != value)
                {
                    _selectedSortOption = value;
                    OnPropertyChanged(nameof(SelectedSortOption));
                    SortData(SelectedSortOption);
                }
            }
        }
        public ObservableCollection<string> SortOptions { get; set; }

        /// <summary>
        /// Loads assets asynchronously from the data service.
        /// </summary>
        /// <returns>An asynchronous task.</returns>
        protected async Task LoadAssetsAsync()
        {
            var assets = await _services.GetAssetsAsync();
            Asset = new List<Assets>(assets.Data);
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

        /// <summary>
        /// Sorts the list of assets based on the selected sort option.
        /// </summary>
        /// <param name="typeSort">The selected sort option.</param>
        private void SortData(string typeSort)
        {
            switch (typeSort)
            {
                case "Sort by Highest price":
                    Asset = new List<Assets>(Asset.OrderByDescending(m => m.PriceUsd));
                    break;

                case "Sort by Lowest price":
                    Asset = new List<Assets>(Asset.OrderBy(m => m.PriceUsd));
                    break;

                case "Sort by Name":
                    Asset = new List<Assets>(Asset.OrderByDescending(m => m.Name));
                    break;

                default:
                    Asset = new List<Assets>(Asset.OrderBy(m => m.Rank));
                    break;
            }
        }
    }
}
