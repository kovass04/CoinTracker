using Windows.UI.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using CoinTracker.Services;

namespace CoinTracker.ViewModels
{
    /// <summary>
    /// ViewModel for managing application settings, including theme selection.
    /// </summary>
    public class SettingViewModel : ObservableObject
    {
        private ElementTheme _currentTheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingViewModel"/> class.
        /// </summary>
        public SettingViewModel() 
        {
            ThemeSettingsModel themeSettingsModel = new ThemeSettingsModel();
            CurrentTheme = themeSettingsModel.LoadTheme();
        }

        /// <summary>
        /// Gets or sets the current application theme.
        /// </summary>
        public ElementTheme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                if (_currentTheme != value)
                {
                    _currentTheme = value;
                    OnPropertyChanged(nameof(CurrentTheme));
                    SaveThemeToSettings(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the default theme is selected.
        /// </summary>
        public bool IsSelectedTheme
        {
            get => CurrentTheme == ElementTheme.Default;
            set
            {
                if (value)
                    CurrentTheme = ElementTheme.Default;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the light theme is selected.
        /// </summary>
        public bool IsSelectedThemeLight
        {
            get => CurrentTheme == ElementTheme.Light;
            set
            {
                if (value)
                    CurrentTheme = ElementTheme.Light;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dark theme is selected.
        /// </summary>
        public bool IsSelectedThemeDark
        {
            get => CurrentTheme == ElementTheme.Dark;
            set
            {
                if (value)
                    CurrentTheme = ElementTheme.Dark;
            }
        }

        /// <summary>
        /// Saves the selected theme to application settings.
        /// </summary>
        /// <param name="theme">The selected theme.</param>
        private void SaveThemeToSettings(ElementTheme theme)
        {
            ThemeSettingsModel themeSettingsModel = new ThemeSettingsModel();
            themeSettingsModel.SaveTheme(theme);
        }
    }
}
