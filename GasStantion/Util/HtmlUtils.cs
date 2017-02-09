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

        public static string Cut(string text)
        {
            if (text.Length > TextMaxLength)
                return text.Substring(0, Math.Min(TextMaxLength, text.Length - 1)) + "...";
            else
                return text;
        }

        public static string Image(string url)
        {
            return url.IsNullOrWhiteSpace() ? "/Images/picture.png" : url;
        }
    }
}