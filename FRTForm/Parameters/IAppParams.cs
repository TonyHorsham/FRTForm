// 19 09 2020 Created by Tony Horsham 13:56


using System.Collections.Generic;
using FRTForm.Models;

namespace FRTForm.Parameters
{
    public interface IAppParams
    {
       public Dictionary<string, IFormSpecs> AppFormSpecsDictionary { get; }
    }
}