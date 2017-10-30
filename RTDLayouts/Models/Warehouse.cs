using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDLayouts.Models
{
    public class Warehouse
    {
        public string Id { get; }
        public DateTime DeliveryDate { get; }
        public int Count { get; }

        public Warehouse(string id, DateTime deliveryDate, int count)
        {
            Id = id;
            DeliveryDate = deliveryDate;
            Count = count;
        }
    }
}
