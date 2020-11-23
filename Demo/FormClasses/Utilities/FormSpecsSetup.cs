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
        public static FRTFormSettings FRTFormSettings
        {
            get
            {
                Dictionary<string, IFormSpecs> formSpecs = new Dictionary<string, IFormSpecs>();
                formSpecs.Add("demoForm", DemoFormSpecs);
                return new FRTFormSettings(formSpecs);
            }
        }

        private static IFormSpecs DemoFormSpecs
        {
            get
            {
                var elements = new List<IFormElement>();
                var editDeleteCloseElement = new EditDeleteCloseElement("DisplayHeader");
                elements.Add(editDeleteCloseElement);
                var submitAndCloseElement = new SubmitAndCloseElement("SubmitHeader", "Save Changes");
                elements.Add(submitAndCloseElement);
                var titleElement = new TitleElement("Title", "populateInForm");
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
                var formSpecs = new DemoFormSpecs(25, elements,
                    formProcessor);
                return formSpecs;
            }
        }
    }
}