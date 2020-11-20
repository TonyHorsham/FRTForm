using System.Threading.Tasks;

namespace FRTForm.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
