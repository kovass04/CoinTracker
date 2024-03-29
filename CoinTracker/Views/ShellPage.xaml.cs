﻿using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoinTracker.Views
{
    /// <summary>
    /// Represents the ShellPage in the application.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        private NavigationViewItem _lastItem;
        public ShellPage()
        {
            this.InitializeComponent();
        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null || item == _lastItem) return;

            var clickedView = item.Tag?.ToString() ?? "SettingsPage";
            if (!NavigateToView(clickedView)) return;
            _lastItem = item;
        }

        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly().GetType($"CoinTracker.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null) return false;

            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag != null && item.Tag.ToString() == "SettingPage")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {

        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }
    }
}
