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
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class ApproveOrderingView : UserControl
    {
        private ApproveOrderingViewModel _viewModel;

        public ApproveOrderingView()
        {
            this.InitializeComponent();
            _viewModel = new ApproveOrderingViewModel();
        }

        private void BackButtonTapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ContinueButtonTapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BackStackPanelTapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void CloseButtonTapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
