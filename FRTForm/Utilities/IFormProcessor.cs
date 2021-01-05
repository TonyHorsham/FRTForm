﻿// 27 06 2020 Created by Tony Horsham 07:43


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FRTForm.Models;
using FRTForm.Parameters;

namespace FRTForm.Utilities
{
    /// <summary>
    /// .HandleClickAsync used to process change to individual elements;
    /// .FormSubmittedAsync used to process all form elements;
    /// .UpdateElementsAsync used to change elements in response to other elements,
    ///      if called directly, the displayOnly parameter may be true,
    ///      if called from the other two methods the parameter will always be false
    /// Passing in SettingsService to all methods provides flexibility 
    /// </summary>
    public interface IFormProcessor
    {
        public Task HandleClickAsync(List<IFormElement> formElements, string elementName,
            IAllParams allSettings);
        public Task UpdateElementsAsync(List<IFormElement> formElements, IAllParams allParams, bool displayOnly);
        public Task FormSubmittedAsync(List<IFormElement> formElements, IAllParams allSettings);
        public event EventHandler ElementsUpdated;

        public IFormProcessor Clone();
    }
}