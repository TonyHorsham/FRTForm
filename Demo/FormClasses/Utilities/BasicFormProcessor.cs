// 28 11 2020 Created by Tony Horsham 13:18

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FRTForm.Models;
using FRTForm.Parameters;
using FRTForm.Utilities;

namespace Demo.FormClasses.Utilities
{
    public class BasicFormProcessor : IFormProcessor
    {
        public Task HandleClickAsync(List<IFormElement> formElements, string elementName, IAllParams allParams)
        {
            throw new NotImplementedException();
        }

        public Task UpdateElementsAsync(List<IFormElement> formElements, IAllParams allParams, bool displayOnly)
        {
            throw new NotImplementedException();
        }

        public async Task FormSubmittedAsync(List<IFormElement> formElements, IAllParams allParams)
        {
            // just ignore
        }

        public event EventHandler ElementsUpdated;
        public IFormProcessor Clone()
        {
            return this.CloneObject();
        }
    }
}