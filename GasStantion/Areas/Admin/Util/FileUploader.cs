using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace GasStantion.Areas.Admin.ViewModels
{
    public static class FileUploader
    {
        private const string uploadDir = "Uploads";

        //Загружает файл
        public static string UploadFile(HttpPostedFileBase file)
        {
            string extension = Path.GetExtension(file.FileName);
            string filename = Guid.NewGuid().ToString() + extension;
            string fullname = Path.Combine(uploadDir, filename);
            string physName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, fullname);

            file.SaveAs(physName);

            return Path.Combine("\\", fullname);
        }

        //Удаляет файл
        public static bool RemoveFile(string filename)
        {
            filename = filename.Substring(1);   //Удаляем первый "/"

            string physName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, filename);

            //Проверки на всякие проблемы с удалением файла
            try
            {
                File.Delete(physName);
            }
            catch (DirectoryNotFoundException ex)
            {
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                return false;
            }

            return true;
        }
    }
}