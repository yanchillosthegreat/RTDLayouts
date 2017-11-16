using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace RTDLayouts.Controls
{
    public partial class RTDCalendarView : CalendarView
    {
        private ScrollViewer _monthViewScrollViewer;
        private CalendarPanel _monthViewPanel;
        public CalendarViewDayItem _currentSelectedDate;
        private readonly SolidColorBrush _lightGrayBrush = new SolidColorBrush(Color.FromArgb(255, 245, 245, 245));


        public RTDCalendarView()
        {
            this.DefaultStyleKey = typeof(RTDCalendarView);
            this.SelectedDatesChanged += OnSelectedDatesChanged;
        }

        protected override void OnApplyTemplate()
        {
            VisualStateManager.GoToState(this, IsLoading ? "ProgressRingActive" : "ProgressRingInactive", true);

            if (_monthViewScrollViewer != null)
            {
                _monthViewScrollViewer.ViewChanging -= OnMonthViewScrollViewerViewChanging;
            }

            if (_monthViewPanel != null)
            {
                _monthViewPanel.Loaded -= OnMonthViewPanelLoaded;
            }

            _monthViewScrollViewer = GetTemplateChild("MonthViewScrollViewer") as ScrollViewer;
            _monthViewPanel = GetTemplateChild("MonthViewPanel") as CalendarPanel;

            if (_monthViewScrollViewer != null)
            {
                _monthViewScrollViewer.ViewChanging += OnMonthViewScrollViewerViewChanging;
            }

            if (_monthViewPanel != null)
            {
                _monthViewPanel.Loaded += OnMonthViewPanelLoaded;
            }

            base.OnApplyTemplate();
        }

        private void OnMonthViewPanelLoaded(object sender, RoutedEventArgs e)
        {
            UpdateCalendarDays();
            UpdateEnableDates();
            RestoreSelectedDay();
            UpdateCalendarViewTodayItemStyle();
        }

        private void RestoreSelectedDay()
        {
            if (_currentSelectedDate == null)
                return;
            _currentSelectedDate.IsBlackout = false;
            _currentSelectedDate.Style = Application.Current.Resources["SelectedDayItem"] as Style;
            if ((_currentSelectedDate.Date.DayOfWeek == DayOfWeek.Saturday || _currentSelectedDate.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                _currentSelectedDate.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void OnMonthViewScrollViewerViewChanging(object sender, ScrollViewerViewChangingEventArgs scrollViewerViewChangingEventArgs)
        {
            UpdateCalendarDays();
            UpdateEnableDates();
            RestoreSelectedDay();
            UpdateCalendarViewTodayItemStyle();
        }

        private void UpdateCalendarDays()
        {
            var uiElements = _monthViewPanel.Children;
            foreach (var uiElement in uiElements)
            {
                var dayItem = (CalendarViewDayItem)uiElement;

                if (_currentSelectedDate != null && dayItem.Date.Date.Equals(_currentSelectedDate.Date.Date))
                {
                    continue;
                }

                dayItem.IsBlackout = true;

                if ((dayItem.Date.DayOfWeek == DayOfWeek.Saturday || dayItem.Date.DayOfWeek == DayOfWeek.Sunday))
                {
                    dayItem.Background = _lightGrayBrush;
                }
            }

            if (_currentSelectedDate == null)
                return;
            _currentSelectedDate.IsBlackout = false;
            _currentSelectedDate.Style = Application.Current.Resources["DefaultDayItem"] as Style;
        }

        public void UpdateIsLoading()
        {
            VisualStateManager.GoToState(this, IsLoading ? "ProgressRingActive" : "ProgressRingInactive", true);
        }

        public void UpdateEnableDates()
        {
            if (EnableDates == null || _monthViewPanel == null)
                return;

            var uiElements = _monthViewPanel.Children;
            foreach (var date in EnableDates)
            {
                foreach (var uiElement in uiElements)
                {
                    var dayItem = (CalendarViewDayItem)uiElement;
                    if (!dayItem.Date.Date.Equals(date.Date))
                        continue;

                    dayItem.IsBlackout = false;
                    break;
                }
            }
        }

        private void OnSelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (_monthViewPanel == null) return;

            var uiElements = _monthViewPanel.Children;

            if (_currentSelectedDate != null)
            {
                _currentSelectedDate.Style = Application.Current.Resources["DefaultDayItem"] as Style;
                if (_currentSelectedDate.Date.DayOfWeek == DayOfWeek.Saturday ||
                    _currentSelectedDate.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    _currentSelectedDate.Background = _lightGrayBrush;
                }
            }

            var selectedDate = args.AddedDates.FirstOrDefault();
            if (selectedDate == DateTimeOffset.MinValue) return;

            var todayItem = uiElements.FirstOrDefault(x => ((CalendarViewDayItem)x).Date.Date.Equals(selectedDate.Date)) as CalendarViewDayItem;
            if (todayItem == null) return;
            todayItem.Style = Application.Current.Resources["SelectedDayItem"] as Style;
            _currentSelectedDate = todayItem;
        }

        public void UpdateCalendarViewTodayItemStyle()
        {
            foreach (var uiElement in _monthViewPanel.Children)
            {
                var dayItem = (CalendarViewDayItem)uiElement;
                if (!dayItem.Date.Date.Equals(DateTime.Now.Date))
                    continue;

                dayItem.IsBlackout = false;
                dayItem.IsEnabled = false;
                dayItem.Style = Application.Current.Resources["TodayDayItem"] as Style;
            }
        }
    }
}
