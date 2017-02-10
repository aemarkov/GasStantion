using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace GasStantion.Areas.Admin.ViewModels
{
    public class UserListItemViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Роль")]
        public string Role { get; set; }
    }
}