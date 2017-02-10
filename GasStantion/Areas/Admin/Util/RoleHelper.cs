using System.Text;

namespace GasStantion.Areas.Admin.ViewModels
{
    public static class RoleHelper
    {
        /// <summary>
        /// Объединяет имена ролей в одну строку
        /// </summary>
        /// <param name="roles">Имена ролей</param>
        /// <returns>Список имен через запятую</returns>
        public static string CombineRoles(params string[] roles)
        {
            var sb =new StringBuilder();
            for (int i = 0; i < roles.Length; i++)
                sb.Append(roles[i]).Append(",");

            sb.Append(roles[roles.Length - 1]);

            return sb.ToString();
        }
    }
}