using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Цена на топливо (марку)
    /// </summary>
    public class Fuel : Entity
    {
        /// <summary>
        /// Марка топлива
        /// </summary>
        [Required(ErrorMessage = "Требуется марка топлива")]
        [MaxLength(10, ErrorMessage = "Длина марки топлива не может быть больше 10 символов")]
        [Display(Name = "Марка топлива")]
        public string FuelName { get; set; }

        /// <summary>
        /// Цена литра топлива в рублях
        /// </summary>
        [Display(Name = "Цена за литр")]
        public double Price { get; set; }

        /// <summary>
        /// Описание топлива
        /// </summary>
        [Display(Name = "Описание")]
        public string FuelDescription { get; set; }
    }
}