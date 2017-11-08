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
    public partial class StepsBarButton : Button
    {
        private const int ArrowLength = 7;
        private Polygon _polygon;

        public StepsBarButton()
        {
            this.DefaultStyleKey = typeof(StepsBarButton);
        }

        protected override void OnApplyTemplate()
        {
            _polygon = GetTemplateChild("Polygon") as Polygon;

            BuildPolygon();
            UpdateState();

            base.OnApplyTemplate();
        }

        private void UpdateState()
        {
            VisualStateManager.GoToState(this, IsEnabled ? "Enable" : "Disable", true);
        }

        private void BuildPolygon()
        {
            switch (Position)
            {
                case Position.First:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width - ArrowLength, 0),
                        new Point(Width, Height / 2),
                        new Point(Width - ArrowLength, Height),
                        new Point(0, Height),
                    };
                    break;
                case Position.Between:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width - ArrowLength, 0),
                        new Point(Width, Height / 2),
                        new Point(Width - ArrowLength, Height),
                        new Point(0, Height),
                        new Point(ArrowLength, Height / 2),
                    };
                    Margin = new Thickness(-(ArrowLength - 1), 0, 0, 0);
                    break;
                case Position.Last:
                    _polygon.Points = new PointCollection
                    {
                        new Point(0, 0),
                        new Point(Width, 0),
                        new Point(Width, Height),
                        new Point(0, Height),
                        new Point(ArrowLength, Height / 2),
                    };
                    Margin = new Thickness(-(ArrowLength - 1), 0, 0, 0);
                    break;
            }
        }
    }
}
