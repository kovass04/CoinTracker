using CoinTracker.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoinTracker.Views
{
    /// <summary>
    /// Represents the ListPage in the application.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPage"/> class.
        /// </summary>
        public ListPage()
        {
            this.InitializeComponent();
            DataContext = new ListViewModel();
        }
    }
}
