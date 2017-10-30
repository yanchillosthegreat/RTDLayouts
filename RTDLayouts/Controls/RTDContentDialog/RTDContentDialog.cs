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
    public sealed class RTDContentDialog : ContentDialog
    {
        private Image _closeImage;

        public RTDContentDialog()
        {
            this.DefaultStyleKey = typeof(RTDContentDialog);

        }

        protected override void OnApplyTemplate()
        {
            if (_closeImage != null)
            {
                _closeImage.Tapped -= OnCloseImageTapped;
            }

            _closeImage = GetTemplateChild("CloseImage") as Image;

            if (_closeImage != null)
            {
                _closeImage.Tapped += OnCloseImageTapped;
            }

            base.OnApplyTemplate();
        }

        private void OnCloseImageTapped(object sender, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            this.Hide();
        }
    }
}
