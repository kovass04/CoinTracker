using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;


using Windows.ApplicationModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CoinTracker.Services;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CoinTracker.ViewModels
{
    public class SettingViewModel : ObservableObject
    {
        public ICommand SetThemeCommand { get; }

        public SettingViewModel() 
        {
            ThemeSettingsModel themeSettingsModel = new ThemeSettingsModel();
            CurrentTheme = themeSettingsModel.LoadTheme();
        }
        private ElementTheme _currentTheme;
        public ElementTheme CurrentTheme
        {
            get { return _currentTheme; }
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

        private void SaveThemeToSettings(ElementTheme theme)
        {
            ThemeSettingsModel themeSettingsModel = new ThemeSettingsModel();
            themeSettingsModel.SaveTheme(theme);
        }

        //TODO temporarily

        private bool _selectedTheme;

        public bool SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    CurrentTheme = ElementTheme.Default;
                }
            }
        }

        private bool _selectedThemeLight;

        public bool SelectedThemeLight
        {
            get { return _selectedThemeLight; }
            set
            {
                if (_selectedThemeLight != value)
                {
                    _selectedThemeLight = value;
                    CurrentTheme = ElementTheme.Light;
                }
            }
        }

        private bool _selectedThemeDark;

        public bool SelectedThemeDark
        {
            get { return _selectedThemeDark; }
            set
            {
                if (_selectedThemeDark != value)
                {
                    _selectedThemeDark = value;
                    CurrentTheme = ElementTheme.Dark;
                }
            }
        }
    }
}
