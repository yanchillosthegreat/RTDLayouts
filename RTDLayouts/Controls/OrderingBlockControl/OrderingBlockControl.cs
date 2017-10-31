using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using RTDLayouts.Models;

namespace RTDLayouts.Controls
{
    public class OrderingBlockControl : Control
    {
        private bool _isExpanded = true;

        private Image _expandImage;

        public OrderingBlockControl()
        {
            this.DefaultStyleKey = typeof(OrderingBlockControl);
        }

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

            UpdateState();

            base.OnApplyTemplate();
        }

        private void OnExpandImageTapped(object sender, TappedRoutedEventArgs e)
        {
            _isExpanded = !_isExpanded;
            UpdateState();
        }

        private void UpdateState()
        {
            VisualStateManager.GoToState(
                this,
                _isExpanded ? "Expanded" : "Collapsed",
                true);

            VisualStateManager.GoToState(
                this,
                Block.Type == OrderingBlockType.Delivery ? "DeliveryState" : "PickupState",
                true);
        }

        public OrderingBlock Block
        {
            get => (OrderingBlock)GetValue(BlockProperty);
            set => SetValue(BlockProperty, value);
        }

        public static readonly DependencyProperty BlockProperty =
            DependencyProperty.Register("Block", typeof(OrderingBlock), typeof(OrderingBlockControl), new PropertyMetadata(default(OrderingBlock)));
    }
}
