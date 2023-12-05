using CoinTracker.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoinTracker.Views
{
    /// <summary>
    /// Represents the SelectedItemPage in the application.
    /// </summary>
    public sealed partial class SelectedItemPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedItemPage"/> class.
        /// </summary>
        public SelectedItemPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the back button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        /// <summary>
        /// Called when the page is navigated to.
        /// </summary>
        /// <param name="e">Navigation event arguments.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                DataContext = new SelectedItemViewModel(e.Parameter.ToString());
            }
        }
    }
}
