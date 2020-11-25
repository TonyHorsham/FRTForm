using System;
using System.Threading.Tasks;
using FRTForm.Services;

namespace Demo.FormClasses.Services
{
    public class DummySmsSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            throw new NotImplementedException();
        }
    }
}
