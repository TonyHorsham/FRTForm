// 23 11 2020 Created by Tony Horsham 16:00

using System.Collections.Generic;
using Demo.FormClasses.Models;
using Demo.FormClasses.Settings;
using FRTForm.BlockTime.Models;
using FRTForm.Models;
using FRTForm.Utilities;

namespace Demo.FormClasses.Utilities
{
    public static class FormSpecsSetup
    {
        /// <summary>
        /// This structure holds the form specifications for an application.
        /// It facilitates testing.
        /// It also allows for a single razor file to handle multiple form options.
        /// </summary>
        public static Dictionary<string, IFormSpecs> FormSpecs
        {
            get
            {
                Dictionary<string, IFormSpecs> formSpecs = new Dictionary<string, IFormSpecs>();
                formSpecs.Add("modalFormSpecs", ModalFormSpecs);
                formSpecs.Add("basicFormSpecs", BasicFormSpecs);
                return formSpecs;
            }
        }
        /// <summary>
        /// Following IFormElements defined 30NOV20
        /// ButtonElement, CloseElement, EditDeleteCloseElement, InputElement, SelectElement,
        /// SubmitAndCloseElement, SubmitElement, TextAreaElement, TitleElement
        /// </summary>
        private static IFormSpecs ModalFormSpecs
        {
            get
            {
                var elements = new List<IFormElement>();
                var editDeleteCloseElement = new EditDeleteCloseElement("DisplayHeader");
                elements.Add(editDeleteCloseElement);
                var submitAndCloseElement = new SubmitAndCloseElement("SubmitHeader", "Save Changes");
                elements.Add(submitAndCloseElement);
                var titleElement = new TitleElement("Title", "All elements displayed for styling initially");
                elements.Add(titleElement);
                var start = new BlockTimeElement("StartTime", "Start", "schedule", false);
                start.IsStart = true;
                start.DisplayIcon = true;
                elements.Add(start);
                var duration = new BlockTimeElement("Duration", "Duration", "update", false);
                duration.IsStart = false;
                duration.DisplayIcon = true;
                elements.Add(duration);
                IFormProcessor formProcessor = new DemoFormProcessor();
                var formSpecs = new FormSpecs("demoForm",25, elements, formProcessor);
                return formSpecs;
            }
        }
        private static IFormSpecs BasicFormSpecs
        {
            get
            {
                var elements = new List<IFormElement>();
                var titleElement = new TitleElement("Title", "All elements displayed for styling initially");
                elements.Add(titleElement);
                var submit = new SubmitElement("Submit", "Test Submit Button");
                elements.Add(submit);
                IFormProcessor formProcessor = new BasicFormProcessor();
                var formSpecs = new FormSpecs("demoForm", 25, elements, formProcessor);
                return formSpecs;
            }
        }
    }
}