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
using RTDLayouts.Common;
using RTDLayouts.Controls;
using RTDLayouts.Models;
using RTDLayouts.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class DeliveryRegistrationView : UserControl
    {
        public Position CurrentStep { get; private set; }

        public Action OnCancelRequested;
        public Action OnAcceptRequested;

        public DeliveryRegistrationViewModel ViewModel { get; private set; }

        public DeliveryRegistrationView()
        {
            this.InitializeComponent();

            DataContext = ViewModel = new DeliveryRegistrationViewModel();
            Loaded += (sender, args) =>
            {
                UpdateState();
            };
        }

        private void UpdateState()
        {
            switch (CurrentStep)
            {
                case Position.First:
                    VisualStateManager.GoToState(FirstStep, "Current", true);
                    VisualStateManager.GoToState(SecondStep, "Next", true);
                    VisualStateManager.GoToState(LastStep, "Next", true);
                    VisualStateManager.GoToState(this, "AddressState", true);
                    break;
                case Position.Second:
                    VisualStateManager.GoToState(FirstStep, "Passed", true);
                    VisualStateManager.GoToState(SecondStep, "Current", true);
                    VisualStateManager.GoToState(LastStep, "Next", true);
                    VisualStateManager.GoToState(this, "DateTimeState", true);
                    break;
                case Position.Last:
                    VisualStateManager.GoToState(FirstStep, "Passed", true);
                    VisualStateManager.GoToState(SecondStep, "Passed", true);
                    VisualStateManager.GoToState(LastStep, "Current", true);
                    VisualStateManager.GoToState(this, "RecipientFormState", true);
                    break;
            }
        }

        private void MoveBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (CurrentStep)
            {
                case Position.First:
                    OnCancelRequested?.Invoke();
                    break;
                case Position.Second:
                    CurrentStep = Position.First;
                    break;
                case Position.Last:
                    CurrentStep = Position.Second;
                    break;
            }
            UpdateState();
        }

        private void MoveForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (CurrentStep)
            {
                case Position.First:
                    CurrentStep = Position.Second;
                    break;
                case Position.Second:
                    CurrentStep = Position.Last;
                    break;
                case Position.Last:
                    OnAcceptRequested?.Invoke();
                    break;
            }
            UpdateState();
        }

        private void StepsBarButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            if (!(sender is StepsBarButton stepsBarButton)) return;

            CurrentStep = stepsBarButton.Position;
            UpdateState();
        }

        private void DeliveryAddressViewCancelButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            OnCancelRequested?.Invoke();
        }

        private void DeliveryAddressViewForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentStep = Position.Second;
            UpdateState();
        }

        private void DeliveryDateTimesViewBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentStep = Position.First;
            UpdateState();
        }

        private void DeliveryDateTimeViewForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentStep = Position.Last;
            UpdateState();
        }

        private void DeliveryRecipientViewBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentStep = Position.Second;
            UpdateState();
        }

        private void DeliveryRecipientViewFinishButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            OnAcceptRequested?.Invoke();
        }
    }
}
