using System;
using Microsoft.Ajax.Utilities;

namespace GasStantion.Util
{
    /// <summary>
    /// Различные полезные вспомогательные функции для
    /// размектки
    /// </summary>
    public static class HtmlUtils
    {
        private const int TextMaxLength = 150;

        public static string Cut(string text, int maxLength = TextMaxLength)
        {
            if (text.Length > maxLength)
                return text.Substring(0, Math.Min(maxLength, text.Length - 1)) + "...";
            else
                return text;

        }

        public static string Image(string url)
        {
            return url.IsNullOrWhiteSpace() ? "/Images/picture.png" : url;
        }
    }
}