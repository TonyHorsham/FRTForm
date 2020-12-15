// 25 11 2020 Created by Tony Horsham 16:36

using System.Collections.Generic;
using FRTForm.Models;
using FRTForm.Utilities;

namespace Demo.FormClasses.Models
{
    public class FormSpecs : IFormSpecs
    {
        public FormSpecs(string formId, 
            List<IFormElement> elements, IFormProcessor formProcessor)
        {
            FormId = formId;
            Elements = elements;
            FormProcessor = formProcessor;
        }

        public string FormId { get; }
        public List<IFormElement> Elements { get; }
        public IFormProcessor FormProcessor { get; }
        public virtual IFormSpecs Clone()
        {
            var elements = new List<IFormElement>();
            // need to avoid passing elements by reference
            // Because FormSpecsDictionary is static
            foreach (var element in this.Elements)
            {
                var elementClone = element.Clone();
                elements.Add(elementClone);
            }
            var formSpecsClone = new FormSpecs(this.FormId, elements, this.FormProcessor.Clone());
            return formSpecsClone;
        }
    }
}