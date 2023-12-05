using CoinTracker.Models;
using CoinTracker.Services;
using System.Threading.Tasks;

namespace CoinTracker.ViewModels
{
    /// <summary>
    /// ViewModel for managing the details of a selected asset.
    /// </summary>
    public class SelectedItemViewModel : BaseViewModel
    {
        private readonly DataServices _services;
        private Assets _assetsId;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedItemViewModel"/> class.
        /// </summary>
        /// <param name="id">The identifier of the selected asset.</param>
        public SelectedItemViewModel(string id) 
        {
            _services = new DataServices();
            _ = LoadAssetsIdAsync(id);
        }

        /// <summary>
        /// Gets or sets the details of the selected asset.
        /// </summary>
        public Assets AssetsId
        {
            get => _assetsId;
            set
            {
                SetProperty(ref _assetsId, value);
            }
        }

        /// <summary>
        /// Loads details of the selected asset asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the selected asset.</param>
        /// <returns>An asynchronous task.</returns>
        protected async Task LoadAssetsIdAsync(string id)
        {
            var assetsId = await _services.GetAssetsIdAsync(id);
            AssetsId = assetsId.Data;
        }
    }
}
