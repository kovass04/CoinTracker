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
            string date = "m1";
            LoadChartsAsync(Id, date);
        }
        /*public SelectedItemViewModel(string Id, string date) : this(Id)
        {
            _ = LoadChartsAsync(Id, date);
        }*/

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
        //TODO finalize the page, develop the interface, add graphics
        private List<Charts> _charts;
        public List<Charts> Charts
        {
            get => _charts;
            set
            {
                SetProperty(ref _charts, value);
            }
        }
        protected async Task LoadChartsAsync(string Id, string date)
        {
            var charts = await _Services.GetChartsAsync(Id, date);
            Charts = new List<Charts>(charts.Data);
        }
    }
}
