using System;
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
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    // Text="Выбранные товары будут выданы покупателю сегодня 24 сентября, сразу  после оплаты счета."

    public sealed partial class PickupRegistrationView : UserControl
    {
        public Action OnCancelRequested;
        public Action OnAcceptRequested;

        private PickupRegistrationViewModel _viewModel;

        public PickupRegistrationView()
        {
            this.InitializeComponent();
            this.DataContext = _viewModel = new PickupRegistrationViewModel();

            NowContentTextBlock.Text =
                string.Format("Выбранные товары будут выданы покупателю сегодня {0}, сразу  после оплаты счета.",
                DateTime.Now.ToString("d MMMM"));

            CalendarDatePicker.MinDate = new DateTimeOffset(DateTime.Today.AddDays(1));
            CalendarDatePicker.MaxDate = new DateTimeOffset(DateTime.Today.AddDays(90));

            VisualStateManager.GoToState(this, "NowState", true);
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string tag)
            {
                switch (tag)
                {
                    case "Now":
                        VisualStateManager.GoToState(this, "NowState", true);
                        break;
                    case "Later":
                        VisualStateManager.GoToState(this, "LaterState", true);
                        break;
                }
            }
        }

        private void CancelButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            this.OnCancelRequested?.Invoke();
        }

        private void AcceptButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            this.OnAcceptRequested?.Invoke();
        }
    }
}
