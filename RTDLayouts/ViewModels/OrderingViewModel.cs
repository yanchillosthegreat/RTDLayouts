using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTDLayouts.Models;

namespace RTDLayouts.ViewModels
{
    public class OrderingViewModel : BaseViewModel
    {
        private bool _lockCheckBoxesBindingUpdating;

        private int _selectedProductsCount;
        public int SelectedProductsCount
        {
            get => _selectedProductsCount;
            set
            {
                Set(ref _selectedProductsCount, value);
                CheckButtonsAvailability();
            }
        }

        private int _totalProductsCount;
        public int TotalProductsCount
        {
            get => _totalProductsCount;
            set => Set(ref _totalProductsCount, value);
        }

        private int _readyForExecutionProductsCount;
        public int ReadyForExecutionProductsCount
        {
            get => _readyForExecutionProductsCount;
            set => Set(ref _readyForExecutionProductsCount, value);
        }

        private int _totalPrice;
        public int TotalPrice
        {
            get => _totalPrice;
            set => Set(ref _totalPrice, value);
        }

        private int _deliveryPrice;
        public int DeliveryPrice
        {
            get => _deliveryPrice;
            set => Set(ref _deliveryPrice, value);
        }

        public ObservableCollection<OrderingProduct> Products { get; }

        private bool _selectAllProductsCheckBoxSelected;
        public bool SelectAllProductsCheckBoxSelected
        {
            get => _selectAllProductsCheckBoxSelected;
            set => Set(ref _selectAllProductsCheckBoxSelected, value);
        }

        private bool _deliveryButtonIsActive;
        public bool DeliveryButtonIsActive
        {
            get => _deliveryButtonIsActive;
            set => Set(ref _deliveryButtonIsActive, value);
        }

        private bool _pickupButtonIsActive;
        public bool PickupButtonIsActive
        {
            get => _pickupButtonIsActive;
            set => Set(ref _pickupButtonIsActive, value);
        }

        public OrderingViewModel()
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

            TotalProductsCount = Products.Count;
            TotalPrice = Products.Sum(x => x.TotalPrice);
            //ReadyForExecutionProductsCount = 0;
            //DeliveryPrice = 800;

            Products.ToList().ForEach(x => x.PropertyChanged += OnProductPropertyChanged);
        }
        
        private void OnProductPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(OrderingProduct.IsSelected))
            {
                SelectedProductsCount = Products.Count(x => x.IsSelected);

                _lockCheckBoxesBindingUpdating = true;
                if (sender is OrderingProduct product && !product.IsSelected)
                {
                    SelectAllProductsCheckBoxSelected = false;
                }
                else if (Products.All(x => x.IsSelected))
                {
                    SelectAllProductsCheckBoxSelected = true;
                }
                _lockCheckBoxesBindingUpdating = false;
            }
        }

        public void SelectAllProducts()
        {
            if (_lockCheckBoxesBindingUpdating) return;

            Products.ToList().ForEach(x => x.IsSelected = true);
            SelectedProductsCount = Products.Count;
        }

        public void UnselectAllProducts()
        {
            if (_lockCheckBoxesBindingUpdating) return;

            Products.ToList().ForEach(x => x.IsSelected = false);
            SelectedProductsCount = 0;
        }

        private void CheckButtonsAvailability()
        {
            if (SelectedProductsCount == 0)
            {
                DeliveryButtonIsActive = PickupButtonIsActive = false;
            }
            else
            {
                DeliveryButtonIsActive = PickupButtonIsActive = true;
            }
        }
    }
}
