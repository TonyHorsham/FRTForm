// 26 11 2020 Created by Tony Horsham 15:46

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.FormClasses.Services;
using Demo.FormClasses.Settings;
using Demo.FormClasses.Utilities;
using FRTForm.BlockTime.Enums;
using FRTForm.BlockTime.Models;
using FRTForm.BlockTime.Settings;
using FRTForm.Models;
using FRTForm.Settings;
using FRTForm.Utilities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DemoFormTests
    {
        private Dictionary<string, IFormSpecs> _formSpecsDictionary;
        private string _formSpecName = "demoFormSpecs";
        private IAllSettingsBT _allSettings;
        private DemoFormProcessor _testFormProcessor;
        private List<IFormElement> _testFormElements;
        private string _formId;

        [SetUp]
        public void Setup()
        {
            _formSpecsDictionary = FormSpecsSetup.FormSpecsDictionary;
            var appSettings = new ApplicationSettings("url", new DummySmsSender(),
                new DummyEmailSender(), _formSpecsDictionary);
            var calendarSettings = new CalendarSettings
            {
                DefaultBlockDuration = 60,
                MaxBlockDuration = 120,
                MinBlockDuration = 30,
                Services = new List<Service>()// needs to be valued after data available
            };
            _allSettings = new AllSettings(appSettings, calendarSettings);
            var calendarId = "anything";
            var calendarDay = new CalendarDay(calendarId, DateTimeOffset.Now, 1);
            var block = new Block(1, DateTimeOffset.Now, TimeSpan.FromHours(1), 1,
                BlockType.Available, calendarId);
            _allSettings.CurrentBlockParameters = new CurrentBlockParameters(block, calendarDay,
                "", false, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            // Because FormSpecsDictionary is static, always use .Clone
            var formSpecs = _formSpecsDictionary[_formSpecName].Clone();
            _testFormProcessor = (DemoFormProcessor) formSpecs.FormProcessor;
            _testFormElements = formSpecs.Elements;
            _formId = formSpecs.FormId;
        }

        #region BasicTests
        [Test]
        public void FormSpecs_AllElements_NumberCorrect()
        {
            var elementsExpected = 10;
            Assert.AreEqual(elementsExpected, _testFormElements.Count);
        }
        [Test]
        public void FormSpecs_SecondAccess_AllElementsNew()
        {
            var formSpecs = _formSpecsDictionary[_formSpecName].Clone();
            var secondElementList = formSpecs.Elements;
            foreach (var element in _testFormElements)
            {
                var secondElement = secondElementList
                    .FirstOrDefault(e => e.Name == element.Name);
                Assert.IsTrue(element.Equals(secondElement));
                Assert.IsFalse(ReferenceEquals(element, secondElement));
            }
        }
        [Test]
        public void FormSpecs_SecondAccess_ProcessorNew()
        {
            var formSpecs = _formSpecsDictionary[_formSpecName].Clone();
            var secondProcessor = formSpecs.FormProcessor;
            var secondElementList = formSpecs.Elements;
            Assert.IsFalse(ReferenceEquals(_testFormProcessor, secondProcessor));
        }
        [Test]
        public void Elements_Includes_NamedElements([Values("DisplayOnlyButton", "Close",
            "DisplayHeader", "TextInput", "Select", "SubmitHeader", "TextArea", "Title",
            "StartTime", "Duration")] string name)
        {
            var element = _testFormElements.FirstOrDefault(fe => fe.Name == name);
            Assert.IsNotNull(element);
            //check that tests do not interfere
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            Assert.AreEqual("All elements displayed for styling initially", title.Value);
        }
        [Test]
        public void FormSpecs_FormId_Correct()
        {
            Assert.AreEqual(_formId, "demoForm");
        }
        #endregion
        [Test]
        public void InitialDisplay_Always_BehavesAsExpected()
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            //this form does not call _testFormProcessor.UpdateElementsAsync when first loaded
            Assert.IsFalse(displayOnlyButton.NotVisible);
            Assert.IsFalse(displayOnlyButton.NotEnabled);
            Assert.IsFalse(closeElement.NotVisible);
            Assert.IsFalse(closeElement.NotEnabled);
            Assert.IsFalse(display.NotVisible);
            Assert.IsFalse(display.NotEnabled);
            Assert.IsFalse(input.NotVisible);
            Assert.IsFalse(input.NotEnabled);
            Assert.IsTrue(input.Required);
            Assert.IsFalse(select.NotVisible);
            Assert.IsFalse(select.NotEnabled);
            Assert.IsFalse(submit.NotVisible);
            Assert.IsFalse(submit.NotEnabled);
            Assert.IsFalse(textArea.NotVisible);
            Assert.IsFalse(textArea.NotEnabled);
            Assert.IsFalse(title.NotVisible);
            Assert.AreEqual("All elements displayed for styling initially", title.Value);
            Assert.IsFalse(start.NotVisible);
            Assert.IsFalse(start.NotEnabled);
            Assert.IsFalse(duration.NotVisible);
            Assert.IsFalse(duration.NotEnabled);
            Assert.IsFalse(ElementOrderCorrect(_testFormElements));
        }
        [Test]
        public async Task DisplayOnlyButton_Always_BehavesAsExpected()
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
            await _testFormProcessor.HandleClickAsync(_testFormElements, "DisplayOnlyButton", _allSettings);
            // This button puts the form into displayOnly mode and changes the element order
            Assert.IsTrue(closeElement.NotVisible);
            Assert.IsFalse(display.NotVisible);
            Assert.IsTrue(submit.NotVisible);
            Assert.IsTrue(displayOnlyButton.NotVisible);
            Assert.IsFalse(title.NotVisible);
            Assert.AreEqual("Now in display only mode", title.Value);
            Assert.IsTrue(input.NotEnabled);
            Assert.IsTrue(select.NotEnabled);
            Assert.IsTrue(textArea.NotEnabled);
            Assert.IsTrue(start.NotEnabled);
            Assert.IsTrue(duration.NotEnabled);
            Assert.IsTrue(ElementOrderCorrect(_testFormElements));
        }
        [Test]
        public async Task Edit_Always_BehavesAsExpected()
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
            // this must be called before each subsequent test to get element order
            await _testFormProcessor.HandleClickAsync(_testFormElements, "DisplayOnlyButton", _allSettings);
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
            EditModeCorrect(_testFormElements);
            Assert.IsTrue(ElementOrderCorrect(_testFormElements));
        }
        #region Utilities

        private bool ElementOrderCorrect(List<IFormElement> formElements)
        {
            // initially in alphabetical order, but after button click should always be in this order
            var correct = true;
            if (formElements[0].Name != "Close") correct = false;
            else if (formElements[1].Name != "DisplayHeader") correct = false;
            else if (formElements[2].Name != "SubmitHeader") correct = false;
            else if (formElements[3].Name != "DisplayOnlyButton") correct = false;
            else if (formElements[4].Name != "Title") correct = false;
            else if (formElements[5].Name != "TextInput") correct = false;
            else if (formElements[6].Name != "Select") correct = false;
            else if (formElements[7].Name != "TextArea") correct = false;
            else if (formElements[8].Name != "StartTime") correct = false;
            else if (formElements[9].Name != "Duration") correct = false;
            return correct;
        }

        private void EditModeCorrect(List<IFormElement> formElements)
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            Assert.IsTrue(closeElement.NotVisible);
            Assert.IsTrue(display.NotVisible);
            Assert.IsFalse(submit.NotVisible);
            Assert.IsTrue(submit.NotEnabled);
            Assert.IsTrue(displayOnlyButton.NotVisible);
            Assert.IsFalse(title.NotVisible);
            Assert.AreEqual("Now in edit mode", title.Value);
            Assert.IsFalse(input.NotEnabled);
            Assert.IsTrue(input.Required);
            Assert.IsFalse(select.NotEnabled);
            Assert.IsFalse(textArea.NotEnabled);
            Assert.IsFalse(start.NotEnabled);
            Assert.IsFalse(duration.NotEnabled);
            Assert.IsTrue(ElementOrderCorrect(_testFormElements));
        }
        #endregion
    }
}