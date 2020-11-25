// 25 11 2020 Created by Tony Horsham 16:36
// Copyright T & D H Family Trust

using System.Collections.Generic;
using FRTForm.Models;
using FRTForm.Utilities;

namespace Demo.FormClasses.Models
{
    public class FormSpecs : IFormSpecs
    {
        public FormSpecs(string formId, int labelWidth,
            List<IFormElement> elements, IFormProcessor formProcessor)
        {
            FormId = formId;
            LabelWidth = labelWidth;
            Elements = elements;
            FormProcessor = formProcessor;
        }

        public string FormId { get; }
        public int LabelWidth { get; set; }
        public List<IFormElement> Elements { get; }
        public IFormProcessor FormProcessor { get; }
    }
}