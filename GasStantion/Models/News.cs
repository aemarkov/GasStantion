using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Title { get; set; }

        /// <summary>
        /// Полный текст новости
        /// </summary>
        [Required(ErrorMessage = "Требуется текст новости")]
        public string Text { get; set; }

        /// <summary>
        /// Url картинки новости
        /// </summary>
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