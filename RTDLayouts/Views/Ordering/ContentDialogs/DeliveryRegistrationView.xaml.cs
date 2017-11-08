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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RTDLayouts.Views
{
    public enum Step
    {
        First,
        Second,
        Last
    }

    public sealed partial class DeliveryRegistrationView : UserControl
    {
        private Step _currentStep = Step.First;

        public DeliveryRegistrationView()
        {
            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                UpdateState();
            };
        }

        private void UpdateState()
        {
            switch (_currentStep)
            {
                case Step.First:
                    VisualStateManager.GoToState(FirstStep, "Current", true);
                    VisualStateManager.GoToState(SecondStep, "Next", true);
                    VisualStateManager.GoToState(LastStep, "Next", true);
                    VisualStateManager.GoToState(this, "AddressFormState", true);
                    break;
                case Step.Second:
                    VisualStateManager.GoToState(FirstStep, "Passed", true);
                    VisualStateManager.GoToState(SecondStep, "Current", true);
                    VisualStateManager.GoToState(LastStep, "Next", true);
                    VisualStateManager.GoToState(this, "DateTimeState", true);
                    break;
                case Step.Last:
                    VisualStateManager.GoToState(FirstStep, "Passed", true);
                    VisualStateManager.GoToState(SecondStep, "Passed", true);
                    VisualStateManager.GoToState(LastStep, "Current", true);
                    VisualStateManager.GoToState(this, "RecipientFormState", true);
                    break;
            }
        }

        private void MoveBackwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (_currentStep)
            {
                case Step.First:
                    //St
                    break;
                case Step.Second:
                    _currentStep = Step.First;
                    break;
                case Step.Last:
                    _currentStep = Step.Second;
                    break;
            }
            UpdateState();
        }

        private void MoveForwardButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            switch (_currentStep)
            {
                case Step.First:
                    _currentStep = Step.Second;
                    break;
                case Step.Second:
                    _currentStep = Step.Last;
                    break;
                case Step.Last:
                    //
                    break;
            }
            UpdateState();
        }
    }
}
