// 21 11 2020 Created by Tony Horsham 15:24

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task HandleClickAsync(List<IFormElement> formElements, string elementName, IAllSettings allSettings)
        {
            if (elementName == "DisplayOnlyButton")
            {
               // Structs make this more complicated!
                // need to find the index, copy with cast, replace
                var originalElement = formElements.FirstOrDefault(e => e.Name == "DisplayOnlyButton");
                Debug.Assert(originalElement != null, nameof(originalElement) + " != null");
                
            }
            else
            {
                throw new NotImplementedException();
            }
            await UpdateElementsAsync(formElements, allSettings, false);
        }

        public async Task UpdateElementsAsync(List<IFormElement> formElements, IAllSettings allSettings, bool displayOnly)
        {
            ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, formElements);


            OnElementsUpdated(EventArgs.Empty);
        }

        public async Task FormSubmittedAsync(List<IFormElement> formElements, IAllSettings allSettings)
        {
            throw new NotImplementedException();
        }

        public event EventHandler ElementsUpdated;
        protected virtual void OnElementsUpdated(System.EventArgs e)
        {
            ElementsUpdated?.Invoke(this, e);
        }

        #region Utilities
        // use for tests as well as locally
        public void ExtractElements(out ButtonElement displayOnlyButton, out CloseElement closeElement,
            out EditDeleteCloseElement display, out InputElement input, out SelectElement select,
            out SubmitAndCloseElement submit, out TextAreaElement textArea,
            out TitleElement title, out BlockTimeElement start, out BlockTimeElement duration,
            List<IFormElement> elements)
        {
            // N.B. Use name of elements rather than inputType, even if only one example of each
            displayOnlyButton = (ButtonElement)elements
                .FirstOrDefault(fe => fe.Name == "DisplayOnlyButton");
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
        private void Setup(IAllSettings allSettings, List<IFormElement> formElements)
        {
            //var allSettingsCalendar = (IAllSettingsCalendar)allSettings;
            //_swCalendarData = allSettingsCalendar.SwCalendarData;
            //// extract services for this calendar
            //_services = allSettings.CalendarSettings.Services;
            //_user = allSettingsCalendar.UserSettings.User;
        }
        #endregion
    }
}