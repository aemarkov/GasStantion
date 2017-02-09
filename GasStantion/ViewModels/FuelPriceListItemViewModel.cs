namespace GasStantion.ViewModels
{
    /// <summary>
    /// Элемент списка цен на топливо
    /// </summary>
    public class FuelPriceListItemViewModel
    {
        public int Id { get; set; }
        public string FuelName { get; set; }
        public double Price { get; set; }
    }
}