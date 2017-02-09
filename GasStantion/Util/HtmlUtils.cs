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
        public static string Cut(string text)
        {
            if (text.Length > 256)
                return text.Substring(0, Math.Min(256, text.Length - 1)) + "...";
            else
                return text;
        }

        public static string Image(string url)
        {
            return url.IsNullOrWhiteSpace() ? "/Images/picture.png" : url;
        }
    }
}