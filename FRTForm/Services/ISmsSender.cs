using System.Threading.Tasks;

namespace FlexResForm.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
