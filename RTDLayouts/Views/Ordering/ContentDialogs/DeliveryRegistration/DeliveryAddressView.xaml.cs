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
    public sealed partial class DeliveryAddressView : UserControl
    {
        private bool _isNewAddressContainerState = true;

        public DeliveryAddressViewModel ViewModel { get; set; }

        public DeliveryAddressView()
        {
            this.InitializeComponent();
            ViewModel = new DeliveryAddressViewModel();
            VisualStateManager.GoToState(this, "NewAddressState", true);
            VisualStateManager.GoToState(this, "ReadyState", true);
        }

        private async void OnDaDataButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LoadingState", true);
            await ViewModel.DoDaData();
            VisualStateManager.GoToState(this, "ReadyState", true);
        }

        private void OnRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string tag)
            {
                switch (tag)
                {
                    case "NewAddress":
                        _isNewAddressContainerState = true;
                        break;
                    case "SavedAddresses":
                        _isNewAddressContainerState = false;
                        break;
                }
            }

            UpdateViewState();
        }

        private void UpdateViewState()
        {
            VisualStateManager.GoToState(this, _isNewAddressContainerState ? "NewAddressState" : "SavedAddressesState", true);
        }

        private void OnCancelButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            CancelButtonTapped?.Invoke(sender, e);
        }

        private void OnForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            ForwardButtonTapped?.Invoke(sender, e);
        }

        public event TappedEventHandler CancelButtonTapped;
        public event TappedEventHandler ForwardButtonTapped;
    }
}
