using System.Threading.Tasks;

namespace FlexResForm.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
