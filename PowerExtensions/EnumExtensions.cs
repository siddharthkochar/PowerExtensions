using System;

namespace PowerExtensions
{
    internal static class EnumExtensions
    {
        public static T ToEnum<T>(this string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an enumerated type");
            }

            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}