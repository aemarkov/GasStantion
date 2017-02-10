using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Отзыв пользователя
    /// </summary>
    public class UserFeedback : Entity
    {
        /// <summary>
        /// Имя или ник пользователя, оставившего отзыв
        /// </summary>
        [Required(ErrorMessage = "Требуется имя")]
        [MaxLength(64, ErrorMessage = "Длина имени не может превышать 64 символа")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        /// <summary>
        /// Оценка пользователя (0-5)
        /// </summary>
        [Range(0,5,ErrorMessage = "Оценка должна быть в диапазоне от 0 до 5")]
        [Display(Name = "Число звезд")]
        public int Stars { get; set; }

        /// <summary>
        /// текст отзыва
        /// </summary>
        [Display(Name = "Комментарий пользователя")]
        [MaxLength(600, ErrorMessage = "Длина комментария не может превышать 600 символов")]
        public string Comment { get; set; }

        /// <summary>
        /// Показывать ли отзыв на главной странице
        /// </summary>
        [Display(Name = "Показывать на главной странице?")]
        public bool IsShowOnMain { get; set; }
    }
}