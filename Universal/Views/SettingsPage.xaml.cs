using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            SetThemeToggle(AppSettings.Theme);
        }

        /// <summary>
        /// Switch the app's theme between light mode and dark mode, and save that setting.
        /// </summary>
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = (FrameworkElement)Window.Current.Content;

            if (((ToggleSwitch)sender).IsOn)
            {
                AppSettings.Theme = AppSettings.NONDEFLTHEME;
                window.RequestedTheme = AppSettings.NONDEFLTHEME;
            }
            else
            {
                AppSettings.Theme = AppSettings.DEFAULTTHEME;
                window.RequestedTheme = AppSettings.DEFAULTTHEME;
            }
        }

        /// <summary>
        /// Set the theme toggle to the correct position (off for the default theme, and on for the non-default).
        /// </summary>
        private void SetThemeToggle(ElementTheme theme)
        {
            if (theme == AppSettings.DEFAULTTHEME)
                tglAppTheme.IsOn = false;
            else
                tglAppTheme.IsOn = true;
        }
    }
}
