using System.ComponentModel.DataAnnotations;

namespace GasStantion.Models
{
    /// <summary>
    /// Цена на топливо (марку)
    /// </summary>
    public class FuelPrice : Entity
    {
        /// <summary>
        /// Марка бензна
        /// </summary>
        [Required(ErrorMessage ="Требуется марка топлива")]
        [MaxLength(10, ErrorMessage = "Длина марки топлива не может быть больше 10 символов")]
        public string PetroliumName { get; set; }

        /// <summary>
        /// Цена бензина в рублях
        /// </summary>
        public double Price { get; set; }
    }
}