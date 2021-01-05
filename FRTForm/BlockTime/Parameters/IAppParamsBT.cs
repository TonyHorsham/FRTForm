// 27 11 2020 Created by Tony Horsham 11:09

using FRTForm.Parameters;
using FRTForm.Services;

namespace FRTForm.BlockTime.Parameters
{
    // ReSharper disable once InconsistentNaming
    public interface IAppParamsBT : IAppParams
    {
        public string DataApi { get; }
        public ISmsSender SmsSender { get; }
        public IEmailSender EmailSender { get; }
    }
}