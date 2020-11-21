// 21 11 2020 Created by Tony Horsham 15:56

using System.Collections.Generic;
using FRTForm.Models;
using FRTForm.Utilities;

namespace Demo.Models
{
    public class DemoFormSpecs : IFormSpecs
    {
        public DemoFormSpecs(int labelWidth, List<IFormElement> elements,
            IFormProcessor formProcessor)
        {
            LabelWidth = labelWidth;
            Elements = elements;
            FormProcessor = formProcessor;
        }

        public string FormId => "demoForm";
        public int LabelWidth { get; set; }
        public List<IFormElement> Elements { get; }
        public IFormProcessor FormProcessor { get; }
    }
}