using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace GasStantion.Areas.Admin.ViewModels
{
    public static class FileUploader
    {
        private const string uploadDir = "Uploads";

        public static string UploadFile(HttpPostedFileBase file)
        {
            string extension = Path.GetExtension(file.FileName);
            string filename = Guid.NewGuid().ToString() + extension;
            string fullname = Path.Combine(uploadDir, filename);

            file.SaveAs(fullname);

            return Path.Combine("\\", fullname, filename);
        }
    }
}