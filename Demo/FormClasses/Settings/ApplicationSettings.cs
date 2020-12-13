// 22 11 2020 Created by Tony Horsham 17:17

using System.Collections.Generic;
using FRTForm.BlockTime.Settings;
using FRTForm.Models;
using FRTForm.Services;
using FRTForm.Settings;

namespace Demo.FormClasses.Settings
{
    /// <summary>
    /// Demo only implements the interface, a real application is likely to have more properties
    /// </summary>
    public readonly struct ApplicationSettings : IApplicationSettingsBT
    {
        public ApplicationSettings(string dataApi, ISmsSender smsSender,
            IEmailSender emailSender, Dictionary<string, IFormSpecs> appFormSpecs)
        {
            DataApi = dataApi;
            SmsSender = smsSender;
            EmailSender = emailSender;
            AppFormSpecsDictionary = appFormSpecs;
        }

        public string DataApi { get; }
        public ISmsSender SmsSender { get; }
        public IEmailSender EmailSender { get; }
        public Dictionary<string, IFormSpecs> AppFormSpecsDictionary { get; }
    }
}