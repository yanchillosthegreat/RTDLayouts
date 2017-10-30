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
    public sealed class StoresListControl : Control
    {
        public StoresListControl()
        {
            this.DefaultStyleKey = typeof(StoresListControl);
        }

        public IEnumerable<Store> Stores
        {
            get => (IEnumerable<Store>)GetValue(StoresProperty);
            set => SetValue(StoresProperty, value);
        }

        public static readonly DependencyProperty StoresProperty =
            DependencyProperty.Register("Stores", typeof(IEnumerable<Store>), typeof(StoresListControl), new PropertyMetadata(default(IEnumerable<Store>)));
    }
}
