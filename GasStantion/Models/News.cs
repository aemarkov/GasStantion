using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GasStantion.Models
{
    /// <summary>
    /// Новость
    /// </summary>
    public class News : Entity
    {
        /// <summary>
        /// Заголовок новости
        /// </summary>
        [Required(ErrorMessage = "Требуется заголовок новости")]
        [MaxLength(64, ErrorMessage = "Длина заголовка не может превышать 64 символа")]
        [Display(Name = "Заголовок новости")]
        public string Title { get; set; }

        /// <summary>
        /// Полный текст новости
        /// </summary>
        [Required(ErrorMessage = "Требуется текст новости")]
        [Display(Name = "Текст новости")]
        [AllowHtml]
        public string Text { get; set; }

        /// <summary>
        /// Url картинки новости
        /// </summary>
        [Display(Name = "Превью")]
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// Теги новости
        /// </summary>
        public ICollection<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            set { _tags = value; }
        }

        private ICollection<Tag> _tags;
    }
}