// 19 09 2020 Created by Tony Horsham 13:56


using System.Collections.Generic;
using FRTForm.Models;
using FRTForm.Services;

namespace FRTForm.Settings
{
    public interface IApplicationSettings
    {
        public string DataApi { get; }
        public ISmsSender SmsSender { get; }
        public IEmailSender EmailSender { get; }
        public Dictionary<string, IFormSpecs> AppFormSpecs { get; }
    }
}