using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Тег новости
    /// </summary>
    public class Tag : Entity
    {
        [Required( ErrorMessage = "Требуется название тега")]
        [Display(Name = "Название тега")]
        public string TagName { get; set; }

        /// <summary>
        /// Новости по данному тегу
        /// </summary>
        public ICollection<News> News
        {
            get { return _news ?? (_news = new List<News>()); }
            set { _news = value; }
        }

        private ICollection<News> _news;
    }
}