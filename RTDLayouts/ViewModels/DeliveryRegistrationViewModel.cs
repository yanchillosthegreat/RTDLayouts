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
        private string _fullAddress;
        public string FullAddress
        {
            get => _fullAddress;
            set
            {
                Set(ref _fullAddress, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _index;
        public string Index
        {
            get => _index;
            set
            {
                Set(ref _index, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _region;
        public string Region
        {
            get => _region;
            set
            {
                Set(ref _region, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _disctrict;
        public string Disctrict
        {
            get => _disctrict;
            set
            {
                Set(ref _disctrict, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                Set(ref _city, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _street;
        public string Street
        {
            get => _street;
            set
            {
                Set(ref _street, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _house;
        public string House
        {
            get => _house;
            set
            {
                Set(ref _house, value);
                RaisePropertyChanged(nameof(CanGoToDateTimeView));
            }
        }

        private string _flat;
        public string Flat
        {
            get => _flat;
            set => Set(ref _flat, value);
        }

        private string _entrance;
        public string Entrance
        {
            get => _entrance;
            set => Set(ref _entrance, value);
        }

        private string _floor;
        public string Floor
        {
            get => _floor;
            set => Set(ref _floor, value);
        }

        private string _code;
        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }

        private bool _hasElevator;
        public bool HasElevator
        {
            get => _hasElevator;
            set => Set(ref _hasElevator, value);
        }

        private DeliveryQuotasEntity _deliveryQuotum;
        public DeliveryQuotasEntity DeliveryQuotum
        {
            get => _deliveryQuotum;
            set => Set(ref _deliveryQuotum, value);
        }

        private Quota _selectedQuota;
        public Quota SelectedQuota
        {
            get => _selectedQuota;
            set
            {
                Set(ref _selectedQuota, value);
                RaisePropertyChanged(nameof(CanGoToRecipientView));
            }
        }

        private DateTimeOffset? _selectedQuotumDate;
        public DateTimeOffset? SelectedQuotumDate
        {
            get => _selectedQuotumDate;
            set => Set(ref _selectedQuotumDate, value);
        }

        private DateTimeOffset? _currentQuotumDate;
        public DateTimeOffset? CurrentQuotumDate
        {
            get => _currentQuotumDate;
            set => Set(ref _currentQuotumDate, value);
        }

        private bool _areDatesLoading = true;
        public bool AreDatesLoading
        {
            get => _areDatesLoading;
            set => Set(ref _areDatesLoading, value);
        }

        public RTDRadioButtonGroup RTDRadioButtonGroup { get; }

        public bool CanGoToDateTimeView =>
            !string.IsNullOrEmpty(FullAddress) && !string.IsNullOrEmpty(Index) &&
            !string.IsNullOrEmpty(Region) && !string.IsNullOrEmpty(Disctrict) &&
            !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Street) &&
            !string.IsNullOrEmpty(House);

        public bool CanGoToRecipientView => SelectedQuota != null;

        private ObservableCollection<DateTime> _enabledDates;
        public ObservableCollection<DateTime> EnabledDates
        {
            get => _enabledDates;
            set => Set(ref _enabledDates, value);
        }

        public DeliveryRegistrationViewModel()
        {
            RTDRadioButtonGroup = new RTDRadioButtonGroup();
        }

        private void ApplyMockDaData()
        {
            FullAddress = "г Москва, ул Тверская, д 6 стр 61, кв 4";
            Index = "123456";
            Region = "Москва";
            Disctrict = "Москва";
            City = "Москва";
            Street = "ул Тверская";
            House = "д 6 стр 61";
            Flat = "4";
            Entrance = "12";
            Floor = "25";
            Code = "23674534";
            HasElevator = true;
        }

        public async Task DoDaData()
        {
            if (string.IsNullOrEmpty(FullAddress)) return;
            await Task.Delay(500);
            ApplyMockDaData();
        }

        public async Task GetDates()
        {
            if (EnabledDates != null) return;

            AreDatesLoading = true;
            await Task.Delay(500);
            EnabledDates = new ObservableCollection<DateTime> { DateTime.Today.AddDays(1), DateTime.Today.AddDays(3) };

            AreDatesLoading = false;
        }

        public async Task LoadQoutums()
        {
            if (SelectedQuotumDate == null)
            {
                DeliveryQuotum = new DeliveryQuotasEntity();
                return;
            }

            if (CurrentQuotumDate != null && CurrentQuotumDate.Value == SelectedQuotumDate.Value) return;

            CurrentQuotumDate = SelectedQuotumDate.Value;

            await Task.Delay(1000);

            DeliveryQuotum = new DeliveryQuotasEntity { DateTime = SelectedQuotumDate?.Date };
            DeliveryQuotum.Quotas.Add(new Quota(0) { DeliveryCost = 800, LoverValue = 12, UpperValue = 14 });
            DeliveryQuotum.Quotas.Add(new Quota(1) { DeliveryCost = 800, LoverValue = 14, UpperValue = 16 });
            DeliveryQuotum.Quotas.Add(new Quota(2) { DeliveryCost = 800, LoverValue = 16, UpperValue = 18 });
            DeliveryQuotum.Quotas.Add(new Quota(3) { DeliveryCost = 800, LoverValue = 19, UpperValue = 22 });
            DeliveryQuotum.Quotas.Add(new Quota(4) { DeliveryCost = 390, LoverValue = 10, UpperValue = 16 });
            DeliveryQuotum.Quotas.Add(new Quota(5) { DeliveryCost = 390, LoverValue = 10, UpperValue = 21 });
            DeliveryQuotum.Quotas.Add(new Quota(6) { DeliveryCost = 390, LoverValue = 10, UpperValue = 22 });
            DeliveryQuotum.Quotas.Add(new Quota(7) { DeliveryCost = 390, LoverValue = 11, UpperValue = 21 });
            DeliveryQuotum.Quotas.Add(new Quota(8) { DeliveryCost = 390, LoverValue = 11, UpperValue = 23 });
        }
    }
}
