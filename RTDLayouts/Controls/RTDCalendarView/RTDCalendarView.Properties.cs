using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace RTDLayouts.Controls
{
    public partial class RTDCalendarView
    {
        #region TodayBackground Property
        public Brush TodayBackground
        {
            get => (Brush)GetValue(TodayBackgroundProperty);
            set => SetValue(TodayBackgroundProperty, value);
        }

        public static readonly DependencyProperty TodayBackgroundProperty =
            DependencyProperty.Register(nameof(TodayBackground), typeof(Brush), typeof(RTDCalendarView), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        #endregion

        #region IsLoading Property

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(RTDCalendarView), new PropertyMetadata(true, IsLoadingPropertyChanged));

        private static void IsLoadingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarDatePicker = d as RTDCalendarView;
            //calendarDatePicker?.UpdateIsLoading();
        }

        #endregion

        #region EnableDates Property

        public IEnumerable<DateTime> EnableDates
        {
            get => (IEnumerable<DateTime>)GetValue(EnableDatesProperty);
            set => SetValue(EnableDatesProperty, value);
        }

        public static readonly DependencyProperty EnableDatesProperty =
            DependencyProperty.Register(nameof(EnableDates), typeof(IEnumerable<DateTime>), typeof(RTDCalendarView), new PropertyMetadata(null, EnableDatesPropertyChanged));

        private static void EnableDatesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarView = d as RTDCalendarView;
            calendarView?.UpdateEnableDates();
        }

        #endregion
    }
}
