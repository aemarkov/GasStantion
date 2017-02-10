using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using GasStantion.Models;

namespace GasStantion.Areas.Admin.ViewModels
{
    /// <summary>
    /// Модель вида для страницы редактирования документов
    /// </summary>
    public class EditDocumentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется название документа")]
        [Display(Name = "Название документа")]
        public string DocumentName { get; set; }

        /// <summary>
        /// Для загрузки изображения
        /// </summary>
        public HttpPostedFileBase UploadedImage { get; set; }

        /// <summary>
        /// Список уже загруженных изображений
        /// </summary>
        public ICollection<DocumentImage> Images { get; set; }
    }
}