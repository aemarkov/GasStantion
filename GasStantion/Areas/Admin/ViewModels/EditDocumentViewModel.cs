using System.ComponentModel.DataAnnotations;

namespace GasStantion.Areas.Admin.ViewModels
{
    /// <summary>
    /// Модель вида для страницы редактирования документов
    /// </summary>
    public class EditDocumentViewModel
    {
        [Required(ErrorMessage = "Требуется название документа")]
        [Display(Name = "Название документа")]
        public string DocumentName { get; set; }


    }
}