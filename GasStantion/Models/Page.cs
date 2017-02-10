using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Простая страница с контентом.
    /// Добавляется в меню и тем самым
    /// расширяет структуру сайта
    /// </summary>
    public class Page : Entity
    {
        /// <summary>
        /// Название страницы
        /// </summary>
        [Required(ErrorMessage = "Требуется название страницы")]
        [MaxLength(64, ErrorMessage = "Длина названия не может превышать 64 символа")]
        [Display(Name = "Заготовок страницы")]
        public string Title { get; set; }

        /// <summary>
        /// Полный текст страницы
        /// </summary>
        [Required(ErrorMessage = "Требуется текст страницы")]
        [Display(Name = "Текст на странице")]
        public string Text { get; set; }

        /// <summary>
        /// Будет ли этот текст отображаться не отдельной страницей, а на главной
        /// </summary>
        public bool IsMainPage { get; set; }
    }
}