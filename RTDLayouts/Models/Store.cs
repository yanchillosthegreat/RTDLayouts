using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.ViewModels;

namespace RTDLayouts.Models
{
    public class Store : BindableBase
    {
        public int Id { get; }
        public string City { get; }
        public string Address { get; }
        public string Metro { get; }
        public int Count { get; }
        public List<string> TimeSchedule { get; }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }
        
        public Store(int id, string city, string address, string metro, int count, List<string> timeSchedule)
        {
            Id = id;
            City = city;
            Address = address;
            Metro = metro;
            Count = count;
            TimeSchedule = new List<string>(timeSchedule);
            IsVisible = true;
        }
    }
}
