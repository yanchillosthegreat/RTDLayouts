using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using RTDLayouts.ViewModels;

namespace RTDLayouts.Common
{
    public class AppSettings : BindableBase
    {
        private static AppSettings _instance;
        public static AppSettings Instance => _instance ?? (_instance = new AppSettings());
    }
}
