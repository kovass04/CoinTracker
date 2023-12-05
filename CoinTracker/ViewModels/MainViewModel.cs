using CoinTracker.Models;
using CoinTracker.Services;
using CoinTracker.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace CoinTracker.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel() 
        {            
            _Services = new DataServices();
            _ = LoadAssetsAsync();
        }

        private readonly DataServices _Services;
        private List<Assets> _assets;
        public List<Assets> Asset
        {
            get => _assets;
            set
            {
                SetProperty(ref _assets, value);
            }
        }
        protected async Task LoadAssetsAsync()
        {
            var assets = await _Services.GetAssetsAsync();
            Asset = new List<Assets>(assets.Data.OrderBy(m => m.Rank).Take(10));
        }

        private Assets _selectedAsset;

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
        private void HandleSelectedAsset()
        {
            if (Window.Current?.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(SelectedItemPage), SelectedAsset?.Id.ToString());
            }
        }
    }
}
