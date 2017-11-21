using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDLayouts.ViewModels
{
    public class DeliveryAddressViewModel : BaseViewModel
    {
        private string _fullAddress;
        public string FullAddress
        {
            get => _fullAddress;
            set
            {
                Set(ref _fullAddress, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _index;
        public string Index
        {
            get => _index;
            set
            {
                Set(ref _index, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _region;
        public string Region
        {
            get => _region;
            set
            {
                Set(ref _region, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _disctrict;
        public string Disctrict
        {
            get => _disctrict;
            set
            {
                Set(ref _disctrict, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                Set(ref _city, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _street;
        public string Street
        {
            get => _street;
            set
            {
                Set(ref _street, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private string _house;
        public string House
        {
            get => _house;
            set
            {
                Set(ref _house, value);
                RaisePropertyChanged(nameof(IsViewValid));
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

        public bool IsViewValid =>
            !string.IsNullOrEmpty(FullAddress) && !string.IsNullOrEmpty(Index) &&
            !string.IsNullOrEmpty(Region) && !string.IsNullOrEmpty(Disctrict) &&
            !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Street) &&
            !string.IsNullOrEmpty(House);

        public DeliveryAddressViewModel()
        {

        }

        public async Task DoDaData()
        {
            if (string.IsNullOrEmpty(FullAddress)) return;
            await Task.Delay(500);
            ApplyMockDaData();
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
    }
}
