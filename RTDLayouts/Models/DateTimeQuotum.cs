using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDLayouts.Models
{
    public class Quota
    {
        public Quota(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public int DeliveryCost { get; set; }
        public int LoverValue { get; set; }
        public int UpperValue { get; set; }
    }

    public class DeliveryQuotasEntity
    {
        public DateTime? DateTime { get; set; }
        public ObservableCollection<Quota> Quotas { get; set; }
        public DeliveryQuotasEntity()
        {
            Quotas = new ObservableCollection<Quota>();
        }
    }
}
