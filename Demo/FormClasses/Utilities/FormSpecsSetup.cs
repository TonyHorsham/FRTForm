// 23 11 2020 Created by Tony Horsham 16:00

using System;
using System.Collections.Generic;
using Demo.FormClasses.Models;
using Demo.FormClasses.Settings;
using FRTForm.BlockTime.Models;
using FRTForm.Enums;
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
        public static Dictionary<string, IFormSpecs> FormSpecsDictionary
        {
            get
            {
                Dictionary<string, IFormSpecs> formSpecs = new Dictionary<string, IFormSpecs>();
                formSpecs.Add("demoFormSpecs", DemoFormSpecs);
                formSpecs.Add("basicFormSpecs", BasicFormSpecs);
                return formSpecs;
            }
        }
        /// <summary>
        /// Following IFormElements implemented 5DEC20
        /// ButtonElement, CloseElement, EditDeleteCloseElement, InputElement, SelectElement,
        /// SubmitAndCloseElement, TextAreaElement, TitleElement
        /// Plus BlockTimeElement in the BlockTime namespace
        /// </summary>
        private static IFormSpecs DemoFormSpecs
        {
            get
            {
                // elements in real examples will be ordered by desired location, NOT alphabetically
                // because they are rendered by iterating through the list 
                var elements = new List<IFormElement>();
                var displayOnlyButtonElement = new ButtonElement("DisplayOnlyButton", "Click to set form to display only",
                    ButtonType.Button, "frtform-btn-primary");
                elements.Add(displayOnlyButtonElement);
                var closeElement = new CloseElement("Close");
                elements.Add(closeElement);
                var editDeleteCloseElement = new EditDeleteCloseElement("DisplayHeader");
                elements.Add(editDeleteCloseElement);
                var inputElement = new InputElement(InputType.Text, "TextInput", "Input a text value",
                    "Input a text value", 0, Int32.MaxValue, true);
                elements.Add(inputElement);
                var selectElement = new SelectElement("Select", "Select a number", "list_alt");
                var options = new Dictionary<int, string>
                {
                    {1, "one"},
                    {2,"two"}
                };
                selectElement.Options = options;
                elements.Add(selectElement);
                var submitAndCloseElement = new SubmitAndCloseElement("SubmitHeader", "Save Changes");
                elements.Add(submitAndCloseElement);
                var textAreaElement = new TextAreaElement("TextArea", "Details" , "notes");
                textAreaElement.RightIcon = "add_to_photos";
                elements.Add(textAreaElement);
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
                var formSpecs = new FormSpecs("demoForm", elements, formProcessor);
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
                var submit = new ButtonElement("Submit", "Test Submit Button", ButtonType.Submit, "frtform-btn-danger");
                elements.Add(submit);
                IFormProcessor formProcessor = new BasicFormProcessor();
                var formSpecs = new FormSpecs("basicForm",  elements, formProcessor);
                return formSpecs;
            }
        }
    }
}