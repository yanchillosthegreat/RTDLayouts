﻿using System;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class ChangeProductsBlockView : UserControl
    {
        public Action OnCancelRequested;
        public Action OnAcceptRequested;

        public ChangeProductsBlockView()
        {
            this.InitializeComponent();
        }

        private void CancelButtonTapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void AcceptButtonTapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
