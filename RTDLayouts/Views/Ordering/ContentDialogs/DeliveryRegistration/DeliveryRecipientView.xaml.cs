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
    public sealed partial class DeliveryRecipientView : UserControl
    {
        public DeliveryRecipientViewModel ViewModel { get; set; }

        public DeliveryRecipientView()
        {
            this.InitializeComponent();
            ViewModel = new DeliveryRecipientViewModel();
        }

        private void OnBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            BackwardButtonTapped?.Invoke(this, e);
        }

        private void OnFinishButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            FinishButtonTapped?.Invoke(this, e);
        }

        public event TappedEventHandler BackwardButtonTapped;
        public event TappedEventHandler FinishButtonTapped;
    }
}
