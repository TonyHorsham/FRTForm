// 19 09 2020 Created by Tony Horsham 13:56


using System.Collections.Generic;
using FRTForm.Models;

namespace FRTForm.Settings
{
    public interface IApplicationSettings
    {
       public Dictionary<string, IFormSpecs> AppFormSpecs { get; }
    }
}