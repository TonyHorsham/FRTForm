// 21 11 2020 Created by Tony Horsham 15:24

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FRTForm.Models;
using FRTForm.Settings;
using FRTForm.Utilities;

namespace Demo.Utilities
{
    public class DemoFormProcessor : IFormProcessor
    {
        public Task HandleClickAsync(List<IFormElement> formElements, string elementName, IAllSettings allSettings)
        {
            throw new NotImplementedException();
        }

        public Task UpdateElementsAsync(List<IFormElement> formElements, IAllSettings allSettings, bool displayOnly)
        {
            throw new NotImplementedException();
        }

        public Task FormSubmittedAsync(List<IFormElement> formElements, IAllSettings allSettings)
        {
            throw new NotImplementedException();
        }

        public event EventHandler ElementsUpdated;
    }
}