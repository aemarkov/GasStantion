using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Отдельное изображение в документе
    /// </summary>
    public class DocumentImage : Entity
    {
        [Required(ErrorMessage = "Требуется файл изображения")]
        [Display(Name = "Файл")]
        public string ImageUrl { get; set; }

        public Document Document { get; set; }
        public int DocumentId { get; set; }
    }
}