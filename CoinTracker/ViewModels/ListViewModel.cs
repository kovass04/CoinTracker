using CoinTracker.Models;
using CoinTracker.Services;
using CoinTracker.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CoinTracker.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ListViewModel() 
        {
            _Services = new DataServices();
            _ = LoadAssetsAsync();

            SortOptions = new ObservableCollection<string>
        {
            "Sort by Rank",
            "Sort by Name",
            "Sort by Highest price",
            "Sort by Lowest price"
        };

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

        private string _selectedSortOption;
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
        private void SortData(string typeSort)
        {
            if (typeSort == "Sort by Highest price") 
            {
                Asset = new List<Assets>(Asset.OrderByDescending(m => m.PriceUsd));
            }
            else if (typeSort == "Sort by Lowest price")
            {
                Asset = new List<Assets>(Asset.OrderBy(m => m.PriceUsd));
            }
            else if(typeSort == "Sort by Name")
            {
                Asset = new List<Assets>(Asset.OrderByDescending(m => m.Name));
            }
            else
            {
                Asset = new List<Assets>(Asset.OrderBy(m => m.Rank));
            }
            
        }
    }
}
