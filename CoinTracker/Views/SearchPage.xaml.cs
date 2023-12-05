using CoinTracker.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoinTracker.Views
{
    /// <summary>
    /// Represents the SearchPage in the application.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPage"/> class.
        /// </summary>
        public SearchPage()
        {
            this.InitializeComponent();
            DataContext = new SearchViewModel();
        }
    }
}
