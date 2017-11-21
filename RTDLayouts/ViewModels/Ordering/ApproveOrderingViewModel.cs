using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.Models;

namespace RTDLayouts.ViewModels
{
    public class ApproveOrderingViewModel : BaseViewModel
    {
        public ObservableCollection<OrderingProduct> Products { get; }
        public ObservableCollection<OrderingBlock> Blocks { get; }

        public ApproveOrderingViewModel()
        {
            Products = new ObservableCollection<OrderingProduct>
            {
                new OrderingProduct("Кофемашина Krups EA829810", "Сейчас", "4 августа", 34990)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790),
                        new OrderingService(name: "Подключение ТВ до 32\" (Подвес)", price: 2490)
                    }
                },
                new OrderingProduct("Смартфон Samsung Galaxy S7 edge 32GB DS Pink", "Сейчас", "5 августа", 1232490)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790)
                    }
                },
                new OrderingProduct("Стиральная машина с сушкой Samsung WD806U2GAGD", "4 августа", "5 августа", 15390)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090)
                    }
                },
                new OrderingProduct("Ноутбук Dell XPS 13 9350-2082", "5 августа", "5 августа", 8590),
                new OrderingProduct("Кофемашина Krups EA829810", "Сейчас", "4 августа", 34990)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790),
                        new OrderingService(name: "Подключение ТВ до 32\" (Подвес)", price: 2490)
                    }
                },
                new OrderingProduct("Смартфон Samsung Galaxy S7 edge 32GB DS Pink", "Сейчас", "5 августа", 1232490)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790)
                    }
                },
                new OrderingProduct("Стиральная машина с сушкой Samsung WD806U2GAGD", "4 августа", "5 августа", 15390)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090)
                    }
                },
                new OrderingProduct("Ноутбук Dell XPS 13 9350-2082", "5 августа", "5 августа", 8590),
                new OrderingProduct("Кофемашина Krups EA829810", "Сейчас", "4 августа", 34990)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790),
                        new OrderingService(name: "Подключение ТВ до 32\" (Подвес)", price: 2490)
                    }
                },
                new OrderingProduct("Смартфон Samsung Galaxy S7 edge 32GB DS Pink", "Сейчас", "5 августа", 1232490)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090),
                        new OrderingService(name: "Подключение ТВ до 32\"", price: 1790)
                    }
                },
                new OrderingProduct("Стиральная машина с сушкой Samsung WD806U2GAGD", "4 августа", "5 августа", 15390)
                {
                    Services = new ObservableCollection<OrderingService>
                    {
                        new OrderingService(name: "Доработка SMART+", price: 4090)
                    }
                },
                new OrderingProduct("Ноутбук Dell XPS 13 9350-2082", "5 августа", "5 августа", 8590)
            };

            Blocks = new ObservableCollection<OrderingBlock>
            {
                new OrderingBlock
                {
                    Products = new ObservableCollection<OrderingProduct>(Products.Take(3)),
                    Address = "г. Москва, ул. Тверская, д. 6 стр. 61, кв. 4",
                    Recipient = "Иванов Константин",
                    Time = "19:00 - 22:00",
                    Date = DateTime.Today,
                    DeliveryPrice = 800,
                    Type = OrderingBlockType.Delivery
                },
                new OrderingBlock
                {
                    Products = new ObservableCollection<OrderingProduct>(Products.Take(2)),
                    Recipient = "Иванов Константин",
                    Date = DateTime.Today,
                    Type = OrderingBlockType.Pickup
                }
            };
        }
    }
}
