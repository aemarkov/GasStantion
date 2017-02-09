using System.Collections.Generic;
using System.Web.Mvc;

namespace GasStantion.Areas.Admin.ViewModels
{
    public static class PathHelper
    {
        public static string PathKey => "__path";

        public static void AddPath(this ViewDataDictionary<dynamic> viewData, string url, string title)
        {
            if(viewData==null)
                return;

            if (viewData[PathKey] == null)
                viewData[PathKey] = new List<PathPart>();

            (viewData[PathKey] as List<PathPart>).Add(new PathPart(url, title));
        }
    }
}