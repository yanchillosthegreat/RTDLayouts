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
        private Position _currentStep = Position.First;
        private bool _isNewAddressContainerState = true;
        private ItemsWrapGrid _itemsWrapGrid;

        public Action OnCancelRequested;
        public Action OnAcceptRequested;

        private DeliveryRegistrationViewModel _viewModel;

        public DeliveryRegistrationView()
        {
            DataContext = _viewModel = new DeliveryRegistrationViewModel();

            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                UpdateState();
                UpdateAddressFormContainerState();
                UpdateDateTimeFormContainerState();
            };

            QuotumsItemsControl.Loaded += OnQuotumsItemsControlLoaded;
        }

        private void UpdateDateTimeFormContainerState()
        {
            VisualStateManager.GoToState(this, "QuotumsCollapsedState", true);
        }

        private void OnQuotumsItemsControlLoaded(object o, RoutedEventArgs routedEventArgs)
        {
            if (QuotumsItemsControl.Items == null) return;

            if (!(QuotumsItemsControl.ItemsPanelRoot is ItemsWrapGrid)) return;
            _itemsWrapGrid = (ItemsWrapGrid) QuotumsItemsControl.ItemsPanelRoot;
            _itemsWrapGrid.MaximumRowsOrColumns = QuotumsItemsControl.Items.Count / 2 + QuotumsItemsControl.Items.Count % 2;

            QuotumsItemsControl.Items.VectorChanged += OnItemsVectorChanged;
        }

        private void OnItemsVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs vectorChangedEventArgs)
        {
            if (QuotumsItemsControl.Items == null || _itemsWrapGrid == null) return;

            _itemsWrapGrid.MaximumRowsOrColumns = QuotumsItemsControl.Items.Count / 2 + QuotumsItemsControl.Items.Count % 2;
        }

        private async void UpdateState()
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
                    await _viewModel.GetDates();
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

        private void QuotaRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RTDRadioButton radioButton && radioButton.Tag is Quota quota)
            {
                _viewModel.SelectedQuota = quota;
            }
        }

        private async void DaDataButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LoadingState", true);
            await _viewModel.DoDaData();
            VisualStateManager.GoToState(this, "ReadyState", true);
        }

        private async void OnCalendarDatePickerClosed(object sender, object e)
        {
            VisualStateManager.GoToState(this, "LoadingState", true);
            await _viewModel.LoadQoutums();
            VisualStateManager.GoToState(this, "ReadyState", true);

            VisualStateManager.GoToState(this,
                _viewModel.SelectedQuotumDate == null ? "QuotumsCollapsedState" : "QuotumsVisibleState", true);
        }
    }
}
