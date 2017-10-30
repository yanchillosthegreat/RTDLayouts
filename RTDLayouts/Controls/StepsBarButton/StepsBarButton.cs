using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RTDLayouts.Controls
{
    public enum BarPosition
    {
        First,
        Between,
        Last
    }

    public sealed class StepsBarButton : Button
    {
        private Polygon _polygon;

        public StepsBarButton()
        {
            this.DefaultStyleKey = typeof(StepsBarButton);
        }

        protected override void OnApplyTemplate()
        {
            _polygon = GetTemplateChild("Polygon") as Polygon;

            IsEnabledChanged += OnIsEnabledChanged;

            BuildPolygon();
            UpdateState();

            base.OnApplyTemplate();
        }

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            UpdateState();
        }

        private void UpdateState()
        {
            VisualStateManager.GoToState(this, IsEnabled ? "Enable" : "Disable", true);
        }

        private void BuildPolygon()
        {
            switch (Position)
            {
                case BarPosition.First:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width - ArrowLength, 0),
                        new Point(Width, Height / 2),
                        new Point(Width - ArrowLength, Height),
                        new Point(0, Height),
                    };
                    break;
                case BarPosition.Between:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width - ArrowLength, 0),
                        new Point(Width, Height / 2),
                        new Point(Width - ArrowLength, Height),
                        new Point(0, Height),
                        new Point(ArrowLength, Height / 2),
                    };
                    this.Margin = new Thickness(-(ArrowLength - 1), 0, 0, 0);
                    break;
                case BarPosition.Last:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width, 0),
                        new Point(Width, Height),
                        new Point(0, Height),
                        new Point(ArrowLength, Height / 2),
                    };
                    this.Margin = new Thickness(-(ArrowLength - 1), 0, 0, 0);
                    break;
            }
        }

        public int Index
        {
            get => (int)GetValue(IndexProperty);
            set => SetValue(IndexProperty, value);
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(StepsBarButton), new PropertyMetadata(1));

        public BarPosition Position
        {
            get => (BarPosition)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(BarPosition), typeof(StepsBarButton), new PropertyMetadata(BarPosition.First));

        public double ArrowLength
        {
            get => (double)GetValue(ArrowLengthProperty);
            set => SetValue(ArrowLengthProperty, value);
        }

        public static readonly DependencyProperty ArrowLengthProperty =
            DependencyProperty.Register("ArrowLength", typeof(double), typeof(StepsBarButton), new PropertyMetadata(0));
    }
}
