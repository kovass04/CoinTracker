using System;
using Windows.UI.Xaml;

namespace CoinTracker.Services
{
    public class ThemeSettingsModel
    {
        /// <summary>
        /// Key used to store and retrieve the application theme in local settings.
        /// </summary>
        private const string _themeKey = "AppTheme";

        /// <summary>
        /// Loads the application theme from local settings.
        /// </summary>
        /// <returns>The loaded application theme as an <see cref="ElementTheme"/> enumeration.</returns>
        public ElementTheme LoadTheme()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.TryGetValue(_themeKey, out var themeValue) && Enum.TryParse(themeValue.ToString(), out ElementTheme theme))
            {
                return theme;
            }
            return ElementTheme.Default;
        }

        /// <summary>
        /// Saves the specified application theme to local settings.
        /// </summary>
        /// <param name="theme">The application theme to be saved.</param>
        public void SaveTheme(ElementTheme theme)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values[_themeKey] = theme.ToString();
        }
    }
}
