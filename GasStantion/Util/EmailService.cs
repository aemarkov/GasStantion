using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace GasStantion.Util
{
    /// <summary>
    /// Сервис отправки сообщений
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Подключите здесь службу электронной почты для отправки сообщения электронной почты.
            return Task.FromResult(0);
        }
    }
}