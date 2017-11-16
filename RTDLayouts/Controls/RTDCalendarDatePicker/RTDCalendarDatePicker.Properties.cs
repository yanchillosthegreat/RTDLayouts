using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RTDLayouts.Controls
{
    public partial class RTDCalendarDatePicker
    {
        #region EnableDates Property

        public IEnumerable<DateTime> EnableDates
        {
            get => (IEnumerable<DateTime>)GetValue(EnableDatesProperty);
            set => SetValue(EnableDatesProperty, value);
        }

        public static readonly DependencyProperty EnableDatesProperty =
            DependencyProperty.Register(nameof(EnableDates), typeof(IEnumerable<DateTime>), typeof(RTDCalendarDatePicker), new PropertyMetadata(null, EnableDatesPropertyChanged));

        private static void EnableDatesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarDatePicker = d as RTDCalendarDatePicker;
            calendarDatePicker?.UpdateEnableDates();
        }

        #endregion

        #region IsLoading Property

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(RTDCalendarDatePicker), new PropertyMetadata(true, IsLoadingPropertyChanged));

        private static void IsLoadingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarDatePicker = d as RTDCalendarDatePicker;
            calendarDatePicker?.UpdateIsLoading();
        }

        #endregion
    }
}
