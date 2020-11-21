// 21 11 2020 Created by Tony Horsham 16:01
// Copyright T & D H Family Trust

using System.Collections.Generic;
using FRTForm.Models;

namespace Demo.Settings
{
    public readonly struct FRTFormSettings
    {
        public FRTFormSettings(Dictionary<string, IFormSpecs> formSpecs)
        {
            FormSpecs = formSpecs;
        }

        public Dictionary<string, IFormSpecs> FormSpecs { get; }
    }
}