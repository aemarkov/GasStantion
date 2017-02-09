using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasStantion.ViewModels
{
    /// <summary>
    /// Модель вида элемента из списка документов
    /// </summary>
    public class DocumentListItemViewModel
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
    }
}