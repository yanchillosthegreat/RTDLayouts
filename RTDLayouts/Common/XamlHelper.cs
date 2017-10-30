using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace RTDLayouts.Common
{
    public static class XamlHelper
    {
        public static T FindVisualChild<T>(DependencyObject depObject) where T : FrameworkElement
        {
            if (depObject is T searchElement) return searchElement;

            var childrenCount = VisualTreeHelper.GetChildrenCount(depObject);
            for (var index = 0; index < childrenCount; index++)
            {
                var child = VisualTreeHelper.GetChild(depObject, index);
                searchElement = FindVisualChild<T>(child);
                if (searchElement != null) return searchElement;
            }

            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var children = child as T;
                if (children != null)
                {
                    yield return children;
                }

                foreach (var childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
}
