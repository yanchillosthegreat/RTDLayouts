using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.Models;

namespace RTDLayouts.ViewModels
{
    public class AvailabilityOnObjectsViewModel : BaseViewModel
    {
        public List<Store> Stores { get; }
        public List<Warehouse> Warehouses { get; }

        private string _filterText = string.Empty;
        public string FilterText
        {
            get => _filterText;
            set
            {
                Set(ref _filterText, value);
                FilterStoresList();
            }
        }

        private void FilterStoresList()
        {
            var filterValue = FilterText.TrimStart().ToLower();

            if (string.IsNullOrEmpty(FilterText))
            {
                Stores.ForEach(x => x.IsVisible = true);
                return;
            }

            Stores.ForEach(x => x.IsVisible = true);
            foreach (var store in Stores.Where(x => !(x.Address.ToLower().Contains(filterValue) || x.Metro.ToLower().Contains(filterValue))))
            {
                store.IsVisible = false;
            }
        }

        public AvailabilityOnObjectsViewModel()
        {
            Stores = new List<Store>
            {
                new Store(321, "г. Москва", "г. Москва, пр-т Мира, д. 91, к. 1", "Алексеевская", 20, new List<string> {"Круглосуточно"}),
                new Store(304, "г. Москва", "г. Москва, ул. Обручева, д. 34/63", "Калужская", 16, new List<string> {"Круглосуточно"}),
                new Store(205, "г. Москва", "г. Москва, Садовая-Спасская ул., д. 3, стр. 3", "Красные ворота", 9,
                    new List<string> { "Пн-Чт, Вс с 10:00 до 23:00", "Пт, Сб с 10:00 до 24:00" }),
                new Store(108, "г. Балашиха", "МО, г. Балашиха, ш. Энтузиастов, д. 36А, ТЦ \"Вертикаль\"", "Щелковская", 30,
                    new List<string> { "Eжедневно с 10:00 до 22:00" }),
                new Store(321, "г. Москва", "г. Москва, пр-т Мира, д. 91, к. 1", "Алексеевская", 20, new List<string> {"Круглосуточно"}),
                new Store(304, "г. Москва", "г. Москва, ул. Обручева, д. 34/63", "Калужская", 16, new List<string> {"Круглосуточно"}),
                new Store(205, "г. Москва", "г. Москва, Садовая-Спасская ул., д. 3, стр. 3", "Красные ворота", 9,
                    new List<string> { "Пн-Чт, Вс с 10:00 до 23:00", "Пт, Сб с 10:00 до 24:00" }),
                new Store(108, "г. Балашиха", "МО, г. Балашиха, ш. Энтузиастов, д. 36А, ТЦ \"Вертикаль\"", "Щелковская", 30,
                    new List<string> { "Eжедневно с 10:00 до 22:00" })
            };

            Warehouses = new List<Warehouse>
            {
                new Warehouse("C025", new DateTime(2017, 9, 10), 5),
                new Warehouse("C111", new DateTime(2017, 9, 12), 16),
                new Warehouse("C087", new DateTime(2017, 9, 12), 5),
                new Warehouse("C015", new DateTime(2017, 9, 12), 16),
                new Warehouse("C056", new DateTime(2017, 9, 14), 5),
                new Warehouse("C012", new DateTime(2017, 9, 14), 16),
                new Warehouse("C120", new DateTime(2017, 9, 20), 5),
                new Warehouse("C025", new DateTime(2017, 9, 10), 5),
                new Warehouse("C111", new DateTime(2017, 9, 12), 16),
                new Warehouse("C087", new DateTime(2017, 9, 12), 5),
                new Warehouse("C015", new DateTime(2017, 9, 12), 16),
                new Warehouse("C056", new DateTime(2017, 9, 14), 5),
                new Warehouse("C012", new DateTime(2017, 9, 14), 16),
                new Warehouse("C120", new DateTime(2017, 9, 20), 5)
            };
        }
    }
}
