using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.ViewModels;

namespace RTDLayouts.Models
{
    public class OrderingProduct : BindableBase
    {
        public string Name { get; }
        public string DeliveryDate { get; }
        public string PickupDate { get; }
        public int TotalPrice { get; }
        public ObservableCollection<OrderingService> Services { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        public OrderingProduct(string name, string pickupDate, string deliveryDate, int totalPrice)
        {
            Name = name;
            DeliveryDate = deliveryDate;
            PickupDate = pickupDate;
            TotalPrice = totalPrice;

            Services = new ObservableCollection<OrderingService>();
        }
    }
}
