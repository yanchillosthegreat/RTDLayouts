using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.Models;

namespace RTDLayouts.ViewModels
{
    public class DeliveryDateTimeViewModel : BaseViewModel
    {
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
                RaisePropertyChanged(nameof(IsViewValid));
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

        public bool IsViewValid => SelectedQuota != null;

        private ObservableCollection<DateTime> _enabledDates;
        public ObservableCollection<DateTime> EnabledDates
        {
            get => _enabledDates;
            set => Set(ref _enabledDates, value);
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
