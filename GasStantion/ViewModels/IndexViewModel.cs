using System.Collections.Generic;
using GasStantion.Models;

namespace GasStantion.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<UserFeedback> Feedbacks { get; set; }
        public string AboutText { get; set; }
    }
}