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
using RTDLayouts.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public sealed partial class DeliveryRegistrationView : UserControl
    {
        private Position _currentStep = Position.First;
        private bool _isNewAddressContainerState = true;

        public Action OnCancelRequested;
        public Action OnAcceptRequested;

        public DeliveryRegistrationView()
        {
            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                UpdateState();
                UpdateAddressFormContainerState();
            };
        }

        private void UpdateState()
        {
            switch (_currentStep)
            {
                case Position.First:
                    VisualStateManager.GoToState(FirstStep, "Current", true);
                    VisualStateManager.GoToState(SecondStep, "Next", true);
                    VisualStateManager.GoToState(LastStep, "Next", true);
                    VisualStateManager.GoToState(this, "AddressFormState", true);
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

        private void UpdateAddressFormContainerState()
        {
            VisualStateManager.GoToState(this, _isNewAddressContainerState ? "NewAddressState" : "SavedAddressesState", true);
        }

        private void MoveBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (_currentStep)
            {
                case Position.First:
                    OnCancelRequested?.Invoke();
                    break;
                case Position.Second:
                    _currentStep = Position.First;
                    break;
                case Position.Last:
                    _currentStep = Position.Second;
                    break;
            }
            UpdateState();
        }

        private void MoveForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (_currentStep)
            {
                case Position.First:
                    _currentStep = Position.Second;
                    break;
                case Position.Second:
                    _currentStep = Position.Last;
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

            _currentStep = stepsBarButton.Position;
            UpdateState();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string tag)
            {
                switch (tag)
                {
                    case "NewAddress":
                        _isNewAddressContainerState = true;
                        break;
                    case "SavedAddresses":
                        _isNewAddressContainerState = false;
                        break;
                }
            }

            UpdateAddressFormContainerState();
        }
    }
}
