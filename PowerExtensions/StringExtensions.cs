using System;
using System.Text;

namespace PowerExtensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return (str == null || str.Length < 1);
        }

        public static bool Contains(this string str, string text, StringComparison comparisonType)
        {
            return str.IndexOf(text, comparisonType) >= 0;
        }

        public static bool ContainsAny(this string str, char[] characters)
        {
            foreach (char character in characters)
            {
                if (str.Contains(character.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsAny(this string str, char[] characters, StringComparison comparisonType)
        {
            foreach (char character in characters)
            {
                if (str.Contains(character.ToString(), comparisonType))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            if (oldValue.IsNullOrEmpty())
            {
                return str;
            }

            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }

        public static string RemoveWhiteSpaces(this string str)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in str)
            {
                if (!Char.IsWhiteSpace(c)) result.Append(c);
            }

            return result.ToString();
        }

        public static bool IsNumber(this string text)
        {
            foreach (char c in text)
            {
                if (!char.IsNumber(c)) return false;
            }

            return true;
        }

        public static string[] Lines(this string text)
        {
            return text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }
    }
}
