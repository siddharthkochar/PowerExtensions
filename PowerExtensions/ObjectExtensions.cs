using System;
using System.Linq;

namespace PowerExtensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull<T>(this T source)
        {
            return null == source;
        }

        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        public static T OrDefault<T>(this T source, T defaultValue)
        {
            return null == source ? defaultValue : source;
        }

    }
}
