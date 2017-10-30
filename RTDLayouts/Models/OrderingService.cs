using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.ViewModels;

namespace RTDLayouts.Models
{
    public class OrderingService : BindableBase
    {
        public string Name { get; }
        public int Price { get; }

        public OrderingService(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
