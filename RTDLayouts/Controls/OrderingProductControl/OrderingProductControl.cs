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
using RTDLayouts.Common;
using RTDLayouts.Models;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RTDLayouts.Controls
{
    public sealed class OrderingProductControl : Control
    {
        private bool _isExpanded;

        private Image _expandImage;

        public OrderingProductControl()
        {
            this.DefaultStyleKey = typeof(OrderingProductControl);
        }

        public OrderingProduct Product
        {
            get => (OrderingProduct)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }

        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(OrderingProduct), typeof(OrderingProductControl), new PropertyMetadata(default(OrderingProduct)));

        protected override void OnApplyTemplate()
        {
            if (_expandImage != null)
            {
                _expandImage.Tapped -= OnExpandImageTapped;
            }

            _expandImage = GetTemplateChild("ExpandImage") as Image;

            if (_expandImage != null)
            {
                _expandImage.Tapped += OnExpandImageTapped;
            }

            Product.PropertyChanged += (sender, args) =>
            {
                UpdateState();
            };

            UpdateState();

            base.OnApplyTemplate();
        }

        private void OnExpandImageTapped(object o, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            _isExpanded = !_isExpanded;

            UpdateState();
        }

        private void UpdateState()
        {
            VisualStateManager.GoToState(
                this,
                Product.Services.Count > 0 ? "ServicesCountTextBlockVisible" : "ServicesCountTextBlockCollapsed",
                true);

            VisualStateManager.GoToState(
                this,
                Product.Services.Count > 0 ? "ShownState" : "HidedState",
                true);

            VisualStateManager.GoToState(
                this,
                _isExpanded ? "ExpandedState" : "CollapsedState",
                true);
        }
    }
}
