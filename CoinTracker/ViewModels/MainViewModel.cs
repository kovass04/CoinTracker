using CoinTracker.Models;
using CoinTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            Asset = new List<Assets>(assets.data);
        }
    }
}
