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
using RTDLayouts.Common;
using RTDLayouts.Controls;
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class AvailabilityOnObjectsView : UserControl
    {
        private readonly AvailabilityOnObjectsViewModel _viewModel;

        private readonly StoresListControl _storesListControl;
        private readonly WarehousesListControl _warehousesListControl;

        public AvailabilityOnObjectsView()
        {
            this.InitializeComponent();
            DataContext = _viewModel = new AvailabilityOnObjectsViewModel();
            _storesListControl = new StoresListControl();
            _warehousesListControl = new WarehousesListControl();

            Loaded += (sender, args) =>
            {
                StoresRadioButton.IsChecked = true;
            };
        }

        private void OnStoresChecked(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = _storesListControl;
            _storesListControl.Stores = _viewModel.Stores;
        }

        private void OnWarehousesChecked(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = _warehousesListControl;
            _warehousesListControl.Warehouses = _viewModel.Warehouses;
        }
    }
}
