using CoinTracker.Models;
using CoinTracker.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
            //ButtonClickCommand = new RelayCommand(ButtonClick);
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
            Asset = new List<Assets>(assets.Data);
        }
        /// <summary>
        ///
        /// </summary>
        //public ICommand ButtonClickCommand { get; private set; }

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
            Console.WriteLine($"Selected asset: {SelectedAsset?.Name}");
        }

    }
}
