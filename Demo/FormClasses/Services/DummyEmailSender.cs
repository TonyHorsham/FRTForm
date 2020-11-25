using System;
using System.Threading.Tasks;
using FRTForm.Services;

namespace Demo.FormClasses.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
