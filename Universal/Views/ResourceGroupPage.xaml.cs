using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Universal.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Library;
using Library.Built;
using Library.Statements;
using Windows.ApplicationModel.DataTransfer;
using Universal.Classes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResourceGroupPage : Page
    {
        ResourceGroupViewModel viewModel;
        
        public ResourceGroupPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            viewModel = new ResourceGroupViewModel();
        }

        private void BCopyCreate_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.CopyContent(tbCreate.Text);
        }

        private void TsForce_Toggled(object sender, RoutedEventArgs e)
        {
            pWarning.Visibility = (tsForce.IsOn ? Visibility.Visible : Visibility.Collapsed);
        }

        string previousLocation;

        private void TsLocation_Toggled(object sender, RoutedEventArgs e)
        {
            if (tsLocation.IsOn)
            {
                cbLocation.SelectedItem = previousLocation;
                cbLocation.Visibility = Visibility.Visible;
            }
            else
            {
                previousLocation = (string) cbLocation.SelectedItem;
                cbLocation.Visibility = Visibility.Collapsed;
                viewModel.Location = null;
            }

            cbLocation.Visibility = (tsLocation.IsOn ? Visibility.Visible : Visibility.Collapsed);
        }

        private void TbName_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            viewModel.Name = tbName.Text;
            viewModel.Update();
        }

        private void BCopyDelete_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.CopyContent(tbDelete.Text);
        }

        private void BCopyRead_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.CopyContent(tbRead.Text);
        }
        private void BCopyUpdate_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.CopyContent(tbUpdate.Text);
        }
    }
}
