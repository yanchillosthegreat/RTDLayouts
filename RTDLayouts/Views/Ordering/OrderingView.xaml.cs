using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RTDLayouts.Controls;
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class OrderingView : UserControl
    {
        private readonly OrderingViewModel _viewModel;

        public OrderingView()
        {
            this.InitializeComponent();
            DataContext = _viewModel = new OrderingViewModel();

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;

            UpdateControlStete();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            UpdateControlStete();
        }

        private void UpdateControlStete()
        {
            VisualStateManager.GoToState(
                this,
                _viewModel.DeliveryPrice > 0 ? "DeliveryTextBlockVisible" : "DeliveryTextBlockCollapsed",
                true);
        }

        private void QuestionMarkImageTapped(object sender, TappedRoutedEventArgs e)
        {
            ToolTip.IsOpen = !ToolTip.IsOpen;
        }

        private void SelectAllCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectAllProducts();
        }

        private void SelectAllCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            _viewModel.UnselectAllProducts();
        }

        private async void DeliveryButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            var contentDialog = new RTDContentDialog
            {
                Content = new DeliveryRegistrationView()
            };
            await contentDialog.ShowAsync();
        }

        private async void PickupButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            var pickupRegistrationView = new PickupRegistrationView();
            var contentDialog = new RTDContentDialog
            {
                Content = pickupRegistrationView
            };
            pickupRegistrationView.OnCancelRequested += () => { contentDialog.Hide();};
            pickupRegistrationView.OnAcceptRequested += () => { contentDialog.Hide(); };
            await contentDialog.ShowAsync();
        }
    }
}
