using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDLayouts.Models
{
    public class DateTimeQuotum
    {
        public int DeliveryCost { get; set; }
        public int LoverValue { get; set; }
        public int UpperValue { get; set; }
    }

    public class DeliveryQuotum
    {
        public DateTime DateTime { get; set; }
        public ObservableCollection<DateTimeQuotum> DateTimeQuotums { get; set; }
        public DeliveryQuotum()
        {
            DateTimeQuotums = new ObservableCollection<DateTimeQuotum>();
        }
    }
}
