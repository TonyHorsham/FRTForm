// 25 11 2020 Created by Tony Horsham 16:36

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
        public virtual IFormSpecs Clone()
        {
            var elements = new List<IFormElement>();
            // need to avoid passing elements by reference
            // Because FormSpecsDictionary is static
            foreach (var element in this.Elements)
            {
                var copy = element.Clone();
                elements.Add(copy);
            }
            var kkk = new FormSpecs(this.FormId, this.LabelWidth, elements, this.FormProcessor.Clone());
            return kkk;
        }
    }
}