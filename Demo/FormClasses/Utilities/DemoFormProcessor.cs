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
            var displayOnly = false;
            if (elementName == "DisplayOnlyButton")
            {
                // Can ignore cast if only dealing with interface properties (as in this example)
                var displayOnlyButton = (ButtonElement) formElements.FirstOrDefault(e => e.Name == "DisplayOnlyButton");
                Debug.Assert(displayOnlyButton != null, nameof(displayOnlyButton) + " != null");
                displayOnly = true;
            }
            else
            {
                throw new NotImplementedException();
            }
            await UpdateElementsAsync(formElements, allSettings, displayOnly);
        }

        

        public async Task UpdateElementsAsync(List<IFormElement> formElements, IAllSettings allSettings, bool displayOnly)
        {
            ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, formElements);
            if (displayOnly)
            {
                SetupDisplayOnly(formElements);
            }
            else
            {
                SetupInitialEdit(formElements);
            }
            OnElementsUpdated(EventArgs.Empty);
        }

        
        public async Task FormSubmittedAsync(List<IFormElement> formElements, IAllSettings allSettings)
        {
            throw new NotImplementedException();
        }

        public event EventHandler ElementsUpdated;
        public virtual IFormProcessor Clone()
        {
            return this.CloneObject();
        }

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
        private void SetupDisplayOnly(List<IFormElement> formElements)
        {
            ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, formElements);
            // change the order of the elements
            formElements.Clear();
            formElements.Add(closeElement);
            formElements.Add(display);
            formElements.Add(submit);
            formElements.Add(displayOnlyButton);
            formElements.Add(title);
            formElements.Add(input);
            formElements.Add(select);
            formElements.Add(textArea);
            formElements.Add(start);
            formElements.Add(duration);
            closeElement.NotVisible = true;
            display.NotVisible = false;
            display.NotEnabled = false;
            submit.NotVisible = true;
            displayOnlyButton.NotVisible = true;
            title.NotVisible = false;
            title.Value = "Now in display only mode";
            input.NotVisible = false;
            input.NotEnabled = true;
            select.NotVisible = false;
            select.NotEnabled = true;
            textArea.NotVisible = false;
            textArea.NotEnabled = true;
            start.NotVisible = false;
            start.NotEnabled = true;
            duration.NotVisible = false;
            duration.NotEnabled = true;
        }
        private void SetupInitialEdit(List<IFormElement> formElements)
        {
            ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, formElements);
            closeElement.NotVisible = true;
            display.NotVisible = true;
            submit.NotVisible = false;
            submit.NotEnabled = true;// form will not be valid initially
            displayOnlyButton.NotVisible = true;
            title.NotVisible = false;
            title.Value = "Now in edit mode";
            input.NotVisible = false;
            input.NotEnabled = false;
            select.NotVisible = false;
            select.NotEnabled = false;
            if (string.IsNullOrEmpty(select.Value))
            {
                var firstKey = select.Options.Keys.First();
                select.Value = select.Options[firstKey];
                
            }
            textArea.NotVisible = false;
            textArea.NotEnabled = false;
            start.NotVisible = false;
            start.NotEnabled = false;
            duration.NotVisible = false;
            duration.NotEnabled = false;
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