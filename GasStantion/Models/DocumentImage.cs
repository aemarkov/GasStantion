using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Отдельное изображение в документе
    /// </summary>
    public class DocumentImage : Entity
    {
        [Required(ErrorMessage = "Требуется файл изображения")]
         public string ImageUrl { get; set; }
    }
}