using CoinTracker.Models;
using CoinTracker.Services;
using CoinTracker.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace CoinTracker.ViewModels
{
    /// <summary>
    /// ViewModel for managing the main view, including a list of top assets.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private readonly DataServices _services;
        private List<Assets> _assets;
        private Assets _selectedAsset;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel() 
        {            
            _services = new DataServices();
            _ = LoadAssetsAsync();
        }

        /// <summary>
        /// Gets or sets the list of top assets.
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
        /// Loads the top assets asynchronously.
        /// </summary>
        /// <returns>An asynchronous task.</returns>
        protected async Task LoadAssetsAsync()
        {
            var assets = await _services.GetAssetsAsync();
            Asset = new List<Assets>(assets.Data.OrderBy(m => m.Rank).Take(10));
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
