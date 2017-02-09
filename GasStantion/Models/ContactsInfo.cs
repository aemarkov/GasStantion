using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasStantion.Models
{
    /// <summary>
    /// Данные для страницы контактов
    /// Содержится только 1 сущность таого типа
    /// </summary>
    public class ContactsInfo : Entity
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string YandexMapUrl { get; set; }
    }
}