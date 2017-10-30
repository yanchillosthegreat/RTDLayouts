using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RTDLayouts.Controls
{
    public sealed class SubmittableTextBox : TextBox
    {
        private Button _submitButton;

        public event TappedEventHandler SubmitButtonTapped;

        public SubmittableTextBox()
        {
            this.DefaultStyleKey = typeof(SubmittableTextBox);
        }

        protected override void OnApplyTemplate()
        {
            if (_submitButton != null)
            {
                _submitButton.Tapped -= OnSubmitButtonTapped;
            }

            _submitButton = GetTemplateChild("SubmitButton") as Button;

            if (_submitButton != null)
            {
                _submitButton.Tapped += OnSubmitButtonTapped;
            }

            UpdateState();

            base.OnApplyTemplate();
        }

        private void OnSubmitButtonTapped(object sender, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            SubmitButtonTapped?.Invoke(this, tappedRoutedEventArgs);
        }

        public bool SubmitButtonRequire
        {
            get => (bool)GetValue(SubmitButtonRequireProperty);
            set => SetValue(SubmitButtonRequireProperty, value);
        }

        public static readonly DependencyProperty SubmitButtonRequireProperty =
            DependencyProperty.Register("SubmitButtonRequire", typeof(bool), typeof(SubmittableTextBox), new PropertyMetadata(false, OnSubmitButtonRequirePropertyChanged));

        private static void OnSubmitButtonRequirePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SubmittableTextBox textBox)
            {
                textBox.UpdateState();
            }
        }

        private void UpdateState()
        {
            VisualStateManager.GoToState(this, SubmitButtonRequire ? "SubmitButtonVisible" : "SubmitButtonCollapsed", false);
        }
    }
}
