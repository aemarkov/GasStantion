using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Документ. Обладает названием и может содержать несколько
    /// изображений
    /// </summary>
    public class Document : Entity
    {
        [Required(ErrorMessage = "Требуется название документа")]
        [Display(Name = "Название документа")]
        public string DocumentName { get; set; }

        /// <summary>
        /// Список изображений, относящихся к документу
        /// </summary>
        public ICollection<DocumentImage> Images
        {
            get { return _images ?? (_images = new List<DocumentImage>()); }
            set { _images = value; }
        }
        private ICollection<DocumentImage> _images;
    }
}