using System.Threading.Tasks;

namespace FRTForm.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
