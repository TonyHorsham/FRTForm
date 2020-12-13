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
        private string _formSpecName = "modalFormSpecs";
        private IAllSettingsBT _allSettings;
        private DemoFormProcessor _testFormProcessor;
        private List<IFormElement> _testFormElements;

        [SetUp]
        public async Task Setup()
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
        }

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
        public async Task DisplayOnlyButton_Always_BehavesAsExpected()
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
            await _testFormProcessor.HandleClickAsync(_testFormElements, "DisplayOnlyButton", _allSettings);
            // This button puts the form into displayOnly mode
            Assert.IsTrue(displayOnlyButton.NotVisible);
            Assert.IsTrue(closeElement.NotVisible);
            Assert.IsTrue(input.NotEnabled);
            Assert.IsTrue(select.NotEnabled);
            Assert.IsTrue(submit.NotVisible);
            Assert.IsTrue(textArea.NotEnabled);
            Assert.IsTrue(start.NotEnabled);
            Assert.IsTrue(duration.NotEnabled);
        }
        #region Utilities

        

        #endregion
    }
}