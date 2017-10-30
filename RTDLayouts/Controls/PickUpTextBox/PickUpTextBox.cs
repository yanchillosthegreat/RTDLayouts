using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RTDLayouts.Controls
{
    public enum PickUpFieldType
    {
        Phone = 0,
        Email = 1,
        Date = 2,
        Name = 3,
        Surname = 4,
        Patronym = 5,
        Boolean = 6,
        Text = 7,
        Other = 10
    }

    public sealed class PickUpTextBox : TextBox
    {
        private TextBlock _necessityIndicatorTextBlock;


        public static readonly DependencyProperty RegexPatternProperty = DependencyProperty.Register(
            "RegexPattern", typeof(string), typeof(PickUpTextBox), new PropertyMetadata(string.Empty));

        public string RegexPattern
        {
            get => (string)GetValue(RegexPatternProperty);
            set => SetValue(RegexPatternProperty, value);
        }

        public static readonly DependencyProperty IsNecessarilyProperty =
            DependencyProperty.Register("IsNecessarily", typeof(bool), typeof(PickUpTextBox), new PropertyMetadata(false, IsNecessarilyPropertyChanged));

        public bool IsNecessarily
        {
            get => (bool)GetValue(IsNecessarilyProperty);
            set => SetValue(IsNecessarilyProperty, value);
        }

        private static void IsNecessarilyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as PickUpTextBox;
            if (textbox == null || !(e.NewValue is bool))
            {
                return;
            }
            textbox.UpdateNecessityIndicator();
        }

        public static readonly DependencyProperty FieldTypeProperty =
            DependencyProperty.Register("FieldType", typeof(PickUpFieldType), typeof(PickUpTextBox), new PropertyMetadata(PickUpFieldType.Text));

        public PickUpFieldType FieldType
        {
            get => (PickUpFieldType)GetValue(FieldTypeProperty);
            set => SetValue(FieldTypeProperty, value);
        }

        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(PickUpTextBox), new PropertyMetadata(string.Empty));

        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register(
            "IsValid", typeof(bool?), typeof(PickUpTextBox), new PropertyMetadata(default(bool?)));

        public bool? IsValid
        {
            get => (bool?)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public PickUpTextBox()
        {
            DefaultStyleKey = typeof(PickUpTextBox);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _necessityIndicatorTextBlock = GetTemplateChild("NecessityIndicatorTextBlock") as TextBlock;

            TextChanged += OnTextChanged;

            UpdateControl();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var textbox = sender as PickUpTextBox;
            if (textbox == null)
            {
                return;
            }

            IsValid = ValidateText(textbox.Text);
            VisualStateManager.GoToState(this, (IsValid.HasValue) ? (IsValid.Value ? "Valid" : "Invalid") : "Indeterminate", true);
        }

        private bool? ValidateText(string text)
        {
            if (text.Length == 0) return null;

            if (FieldType == PickUpFieldType.Phone)
            {
                var result = ValidateAndFormatPhoneNumber(text);
                if (result == null)
                {
                    IsValid = false;
                }
                else
                {
                    TextChanged -= OnTextChanged;
                    Text = result;
                    SelectionStart = Text.Length;
                    TextChanged += OnTextChanged;
                }
            }

            if (FieldType == PickUpFieldType.Date && DateTime.TryParse(text, out DateTime dt))
            {
                if (dt < DateTime.Now.Date) return false;
            }

            return Regex.IsMatch(text, RegexPattern);
        }

        private string ValidateAndFormatPhoneNumber(string phone)
        {
            var phoneString = phone.Replace(" ", string.Empty);
            if (phoneString.Length == 0) return phoneString;
            if (phoneString.Length >= 1 && phoneString[0] != '8') phoneString = "8" + phoneString.Substring(1);
            var isLong = long.TryParse(phoneString, out var phoneInt);
            if (!isLong) return null;

            switch (phoneString.Length)
            {
                case 1:
                    phoneString = $"{phoneInt:#}";
                    break;
                case 2:
                    phoneString = $"{phoneInt:# #}";
                    break;
                case 3:
                    phoneString = $"{phoneInt:# ##}";
                    break;
                case 4:
                    phoneString = $"{phoneInt:# ###}";
                    break;
                case 5:
                    phoneString = $"{phoneInt:# ### #}";
                    break;
                case 6:
                    phoneString = $"{phoneInt:# ### ##}";
                    break;
                case 7:
                    phoneString = $"{phoneInt:# ### ###}";
                    break;
                case 8:
                    phoneString = $"{phoneInt:# ### ### #}";
                    break;
                case 9:
                    phoneString = $"{phoneInt:# ### ### ##}";
                    break;
                case 10:
                    phoneString = $"{phoneInt:# ### ### ## #}";
                    break;
                case 11:
                    phoneString = $"{phoneInt:# ### ### ## ##}";
                    break;
            };

            return phoneString;
        }

        private void UpdateControl()
        {
            UpdateNecessityIndicator();
        }

        private void UpdateNecessityIndicator()
        {
            if (_necessityIndicatorTextBlock != null)
            {
                _necessityIndicatorTextBlock.Visibility = IsNecessarily ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
