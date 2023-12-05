using CoinTracker.Models;
using CoinTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.ViewModels
{
    public class SelectedItemViewModel : BaseViewModel
    {
        public SelectedItemViewModel() { }
        public SelectedItemViewModel(string Id) 
        {
            _Services = new DataServices();
            _ = LoadAssetsIdAsync(Id);
        }

        private readonly DataServices _Services;

        private Assets _assetsId;
        public Assets AssetsId
        {
            get => _assetsId;
            set
            {
                SetProperty(ref _assetsId, value);
            }
        }
        protected async Task LoadAssetsIdAsync(string Id)
        {
            var assetsId = await _Services.GetAssetsIdAsync(Id);
            AssetsId = assetsId.Data;
        }
    }
}
