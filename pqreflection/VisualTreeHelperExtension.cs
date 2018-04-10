using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace pqreflection
{
    // When you need to dig through the visual tree.
    // <see cref="https://stackoverflow.com/questions/16375375/how-do-i-access-a-control-inside-a-xaml-datatemplate"/>
    // <see cref="http://blog.jerrynixon.com/2012/09/how-to-access-named-control-inside-xaml.html"/>
    public static class VisualTreeHelperExtension
    {
        // List all controls below the source input.
        public static List<FrameworkElement> WalkDownVisualTree(this FrameworkElement source)
        {
            if (source == null)
                return null;

            var list = new List<FrameworkElement>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
            {
                var c = VisualTreeHelper.GetChild(source, i);
                if (c is FrameworkElement)
                {
                    list.Add(c as FrameworkElement);
                    list.AddRange(WalkDownVisualTree(c as FrameworkElement));
                }
            }

            return list;
        }

        // List all controls above the source input.
        public static List<FrameworkElement> WalkUpVisualTree(this FrameworkElement source)
        {
            if (source == null)
                return null;

            var list = new List<FrameworkElement>();
            var p = VisualTreeHelper.GetParent(source);
            if (p is FrameworkElement)
            {
                list.Add(p as FrameworkElement);
                list.AddRange(WalkUpVisualTree(p as FrameworkElement));
            }

            return list;
        }

        // Finds an element below the source input by type and name.
        public static T WalkDownVisualTree<T>(this FrameworkElement source, string targetName) where T : FrameworkElement
        {
            if (source == null || string.IsNullOrEmpty(targetName))
                return null;

            var elements = WalkDownVisualTree(source);
            if ((elements?.Count ?? 0) < 1)
                return null;

            foreach (var c in elements)
                if (c is T && c.Name == targetName)
                    return c as T;

            return null;
        }

        // Finds the first instance of type T.
        public static T WalkDownVisualTree<T>(this FrameworkElement source) where T : FrameworkElement
        {
            if (source == null)
                return null;

            var elements = WalkDownVisualTree(source);
            if ((elements?.Count ?? 0) < 1)
                return null;

            foreach (var c in elements)
                if (c is T)
                    return c as T;

            return null;
        }

        // Finds an element above the source input by type and name.
        public static T WalkUpVisualTree<T>(this FrameworkElement source, string targetName) where T : FrameworkElement
        {
            if (source == null || string.IsNullOrEmpty(targetName))
                return null;

            var elements = WalkUpVisualTree(source);
            if ((elements?.Count ?? 0) < 1)
                return null;

            foreach (var c in elements)
                if (c is T && c.Name == targetName)
                    return c as T;

            return null;
        }

        // Finds the first instance of type T.
        public static T WalkUpVisualTree<T>(this FrameworkElement source) where T : FrameworkElement
        {
            if (source == null)
                return null;

            var elements = WalkUpVisualTree(source);
            if ((elements?.Count ?? 0) < 1)
                return null;

            foreach (var c in elements)
                if (c is T)
                    return c as T;

            return null;
        } 
    }
}
