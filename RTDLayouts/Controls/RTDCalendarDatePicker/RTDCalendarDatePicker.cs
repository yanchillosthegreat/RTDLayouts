using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RTDLayouts.Controls
{
    public partial class RTDCalendarDatePicker : CalendarDatePicker
    {
        private Flyout _rootFlyout;
        private RTDCalendarView _calendarView;

        public RTDCalendarDatePicker()
        {
            this.DefaultStyleKey = typeof(RTDCalendarDatePicker);
        }

        protected override void OnApplyTemplate()
        {
            _calendarView = GetTemplateChild("CalendarView") as RTDCalendarView;

            if (_rootFlyout != null)
            {
                _rootFlyout.Opened -= ContextFlyout_Opened;
            }

            _rootFlyout = GetTemplateChild("RootFlyout") as Flyout;

            if (_rootFlyout != null)
            {
                _rootFlyout.Opened += ContextFlyout_Opened;
            }

            UpdateEnableDates();

            _calendarView.IsLoading = IsLoading;

            UpdateStates();

            base.OnApplyTemplate();
        }

        private void ContextFlyout_Opened(object sender, object e)
        {
            _calendarView?.UpdateCalendarViewTodayItemStyle();
        }

        private void UpdateIsLoading()
        {
            if (_calendarView != null)
            {
                _calendarView.IsLoading = IsLoading;
            }

            UpdateStates();
        }

        private void UpdateStates()
        {
            VisualStateManager.GoToState(this, IsLoading ? "Loading" : "Loaded", true);
        }

        private void UpdateEnableDates()
        {
            if (EnableDates?.Count() == 0)
            {
                Date = null;
                return;
            }

            if (_calendarView != null)
            {
                _calendarView.EnableDates = EnableDates;
            }

            Date = EnableDates?.FirstOrDefault();
        }
    }
}
