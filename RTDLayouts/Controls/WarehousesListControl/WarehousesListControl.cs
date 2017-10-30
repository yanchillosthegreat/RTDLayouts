using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using RTDLayouts.Models;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RTDLayouts.Controls
{
    public sealed class WarehousesListControl : Control
    {
        public WarehousesListControl()
        {
            this.DefaultStyleKey = typeof(WarehousesListControl);
        }

        public IEnumerable<Warehouse> Warehouses
        {
            get => (IEnumerable<Warehouse>)GetValue(WarehousesProperty);
            set => SetValue(WarehousesProperty, value);
        }

        public static readonly DependencyProperty WarehousesProperty =
            DependencyProperty.Register("Warehouses", typeof(IEnumerable<Warehouse>), typeof(WarehousesListControl), new PropertyMetadata(default(IEnumerable<Warehouse>)));
    }
}
