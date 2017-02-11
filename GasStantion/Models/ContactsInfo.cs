using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GasStantion.Models
{
    /// <summary>
    /// Данные для страницы контактов
    /// Содержится только 1 сущность таого типа
    /// </summary>
    public class ContactsInfo : Entity
    {
        [Display(Name = "Название АГЗС")]
        public string CompanyName { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Ссылка на карту")]
        [AllowHtml]
        public string YandexMapUrl { get; set; }
    }
}