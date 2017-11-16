using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RTDLayouts.Controls
{
    public sealed class RTDRadioButton : RadioButton
    {
        public RTDRadioButton()
        {
            DefaultStyleKey = typeof(RadioButton);
        }

        public RTDRadioButtonGroup Group
        {
            get => (RTDRadioButtonGroup)GetValue(GroupProperty);
            set => SetValue(GroupProperty, value);
        }

        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(RTDRadioButtonGroup), typeof(RTDRadioButton),
                new PropertyMetadata(default(RTDRadioButton), OnGroupPropertyChanged));

        private static void OnGroupPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var radioButton = sender as RTDRadioButton;
            radioButton?.AttachSelfToGroup();
        }

        private void AttachSelfToGroup()
        {
            Group.AddRadioButton(this);
        }
    }
}
