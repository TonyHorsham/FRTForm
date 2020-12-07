// 21 11 2020 Created by Tony Horsham 15:24

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRTForm.BlockTime.Models;
using FRTForm.Models;
using FRTForm.Settings;
using FRTForm.Utilities;

namespace Demo.FormClasses.Utilities
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
        // use for tests as well as locally
        public void ExtractElements(out ButtonElement displayOnly, out CloseElement closeElement,
            out EditDeleteCloseElement display, out InputElement input, out SelectElement select,
            out SubmitAndCloseElement submit, out TextAreaElement textArea,
            out TitleElement title, out BlockTimeElement start, out BlockTimeElement duration,
            List<IFormElement> elements)
        {
            // N.B. Use name of elements rather than inputType, even if only one example of each
            displayOnly = (ButtonElement)elements
                .FirstOrDefault(fe => fe.Name == "DisplayOnly");
            closeElement = (CloseElement)elements
                .FirstOrDefault(fe => fe.Name == "Close");
            input = (InputElement)elements
                .FirstOrDefault(fe => fe.Name == "TextInput");
            select = (SelectElement)elements
                .FirstOrDefault(fe => fe.Name == "Select");
            display = (EditDeleteCloseElement)elements
                .FirstOrDefault(fe => fe.Name == "DisplayHeader");
            submit = (SubmitAndCloseElement)elements
                .FirstOrDefault(fe => fe.Name == "SubmitHeader");
            textArea = (TextAreaElement)elements
                .FirstOrDefault(fe => fe.Name == "TextArea");
            title = (TitleElement)elements
                .FirstOrDefault(fe => fe.Name == "Title");
            start = (BlockTimeElement)elements
                .FirstOrDefault(fe => fe.Name == "StartTime");
            duration = (BlockTimeElement)elements
                .FirstOrDefault(fe => fe.Name == "Duration");
        }
    }
}