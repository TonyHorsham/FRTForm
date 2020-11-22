using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FRTForm.Services;

namespace Common.Services
{
    public class DummySmsSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            throw new NotImplementedException();
        }
    }
}
