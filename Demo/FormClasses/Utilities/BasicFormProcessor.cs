// 28 11 2020 Created by Tony Horsham 13:18

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FRTForm.Models;
using FRTForm.Settings;
using FRTForm.Utilities;

namespace Demo.FormClasses.Utilities
{
    public class BasicFormProcessor : IFormProcessor
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
        public IFormProcessor Clone()
        {
            return this.CloneObject();
        }
    }
}