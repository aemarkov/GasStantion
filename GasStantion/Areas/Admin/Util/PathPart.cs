namespace GasStantion.Areas.Admin.ViewModels
{
    /// <summary>
    /// Элемент "пути" в админке, чтобы делать удобную навигацию
    /// </summary>
    public class PathPart
    {
        public string Url { get; set; }
        public string Text { get; set; }

        public PathPart() { }

        public PathPart(string url, string text)
        {
            Url = url;
            Text = text;
        }

    }
}