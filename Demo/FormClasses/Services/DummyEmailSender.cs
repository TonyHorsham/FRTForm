using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FRTForm.Services;

namespace Common.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
