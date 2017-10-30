using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.ViewModels;

namespace RTDLayouts.Models
{
    public enum OrderingBlockType
    {
        Delivery,
        Pickup
    }

    public class OrderingBlock : BindableBase
    {
        private string _address;
        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        private string _recipient;
        public string Recipient
        {
            get => _recipient;
            set => Set(ref _recipient, value);
        }

        private OrderingBlockType _type;
        public OrderingBlockType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        private string _time;
        public string Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => Set(ref _date, value);
        }

        private int _deliveryPrice;
        public int DeliveryPrice
        {
            get => _deliveryPrice;
            set => Set(ref _deliveryPrice, value);
        }

        public ObservableCollection<OrderingProduct> Products { get; set; }

        public OrderingBlock()
        {
            Products = new ObservableCollection<OrderingProduct>();
        }
    }
}
