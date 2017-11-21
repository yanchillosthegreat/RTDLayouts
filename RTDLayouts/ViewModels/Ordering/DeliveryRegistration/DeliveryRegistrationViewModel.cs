using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.Web.Syndication;
using Newtonsoft.Json.Bson;
using RTDLayouts.Controls;
using RTDLayouts.Models;

namespace RTDLayouts.ViewModels
{
    public class DeliveryRegistrationViewModel : BaseViewModel
    {
        public DeliveryAddressViewModel DeliveryAddressViewModel { get; }
        public DeliveryDateTimeViewModel DeliveryDateTimeViewModel { get; }
        public DeliveryRecipientViewModel DeliveryRecipientViewModel { get; }

        public DeliveryRegistrationViewModel()
        {
            DeliveryAddressViewModel = new DeliveryAddressViewModel();
            DeliveryDateTimeViewModel = new DeliveryDateTimeViewModel();
            DeliveryRecipientViewModel = new DeliveryRecipientViewModel();
        }
    }
}
