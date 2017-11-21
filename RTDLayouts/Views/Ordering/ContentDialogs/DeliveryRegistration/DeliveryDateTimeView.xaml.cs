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
using RTDLayouts.Controls;
using RTDLayouts.Models;
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class DeliveryDateTimeView : UserControl
    {
        public DeliveryDateTimeViewModel ViewModel { get; set; }
        private ItemsWrapGrid _itemsWrapGrid;

        public DeliveryDateTimeView()
        {
            this.InitializeComponent();
            ViewModel = new DeliveryDateTimeViewModel();

            VisualStateManager.GoToState(this, "ReadyState", true);
            VisualStateManager.GoToState(this, "QuotumsCollapsedState", true);

            Loaded += async (sender, args) =>
            {
                await ViewModel.GetDates();
            };
        }

        private void OnItemsVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs vectorChangedEventArgs)
        {
            if (QuotumsItemsControl.Items == null) return;

            _itemsWrapGrid.MaximumRowsOrColumns = QuotumsItemsControl.Items.Count / 2 + QuotumsItemsControl.Items.Count % 2;
        }

        private void OnBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            BackwardButtonTapped?.Invoke(sender, e);
        }

        private void OnForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            ForwardButtonTapped?.Invoke(sender, e);
        }

        private void OnQuotaRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RTDRadioButton radioButton && radioButton.Tag is Quota quota)
            {
                ViewModel.SelectedQuota = quota;
            }
        }

        private async void OnCalendarDatePickerClosed(object sender, object e)
        {
            VisualStateManager.GoToState(this, "LoadingState", true);
            await ViewModel.LoadQoutums();
            VisualStateManager.GoToState(this, "ReadyState", true);
            VisualStateManager.GoToState(
                this, ViewModel.SelectedQuotumDate == null ? "QuotumsCollapsedState" : "QuotumsVisibleState", true);
        }

        private void OnItemsWrapGridLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is ItemsWrapGrid itemsWrapGrid)) return;
            if (QuotumsItemsControl.Items == null) return;

            QuotumsItemsControl.Items.VectorChanged -= OnItemsVectorChanged;

            _itemsWrapGrid = itemsWrapGrid;
            _itemsWrapGrid.MaximumRowsOrColumns = 
                QuotumsItemsControl.Items.Count / 2 + QuotumsItemsControl.Items.Count % 2;

            QuotumsItemsControl.Items.VectorChanged += OnItemsVectorChanged;
        }

        public event TappedEventHandler BackwardButtonTapped;
        public event TappedEventHandler ForwardButtonTapped;
    }
}
