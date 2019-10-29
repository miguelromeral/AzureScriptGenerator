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

        DataPackage dataPackage;

        public ResourceGroupPage()
        {
            this.InitializeComponent();

            viewModel = new ResourceGroupViewModel();
        }
        
        private void TbName_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Update();
        }

        private void BCopyCreate_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.CopyContent(tbCreate.Text);
        }

        private void TsForce_Toggled(object sender, RoutedEventArgs e)
        {
            pWarning.Visibility = (tsForce.IsOn ? Visibility.Visible : Visibility.Collapsed);
            Update();
        }

        private void Update()
        {
            string name = tbName.Text;
            if (!String.IsNullOrEmpty(name))
            {
                viewModel.UpdateCommand(name, tsForce.IsOn);
            }
            else
            {
                viewModel.Command = null;
            }
        }
    }
}
