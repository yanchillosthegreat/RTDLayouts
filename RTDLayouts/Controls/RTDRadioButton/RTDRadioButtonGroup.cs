﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RTDLayouts.Controls
{
    public class RTDRadioButtonGroup
    {
        private List<RTDRadioButton> _radioButtons;
        public bool SelectFirstAddedRadioButton { get; set; }

        public RTDRadioButtonGroup()
        {
            _radioButtons = new List<RTDRadioButton>();
        }

        public void AddRadioButton(RTDRadioButton radioButton)
        {
            _radioButtons.Add(radioButton);
            radioButton.IsEnabledChanged += OnRadioButtonIsEnabledChanged;
            UpdateState();
        }

        private void OnRadioButtonIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (!(sender is RTDRadioButton radioButton)) return;

            radioButton.IsChecked = false;
            UpdateState();
        }

        private void UpdateState()
        {
            if (_radioButtons.Any(x => x.IsChecked ?? false)) return;

            if (_radioButtons.FirstOrDefault(x => x.IsEnabled) is RTDRadioButton firstRadioButton)
            {
                firstRadioButton.IsChecked = SelectFirstAddedRadioButton;
            }
        }
    }
}
