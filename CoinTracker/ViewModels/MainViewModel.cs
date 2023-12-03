using CoinTracker.Models;
using CoinTracker.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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
        //TODO complete the selection
        private void HandleSelectedAsset()
        {
            Console.WriteLine($"Selected asset: {SelectedAsset?.Name}");
        }

    }
}
