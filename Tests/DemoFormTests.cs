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
        private IAllSettingsBT _allSettings;
        private DemoFormProcessor _testFormProcessor;
        private List<IFormElement> _testFormElements;

        [SetUp]
        public async Task Setup()
        {
            var formSpecs = FormSpecsSetup.FormSpecs;
            var appSettings = new ApplicationSettings("url", new DummySmsSender(),
                new DummyEmailSender(), formSpecs);
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
            var formSpec = formSpecs["modalFormSpecs"];
            _testFormProcessor = (DemoFormProcessor) formSpec.FormProcessor;
            _testFormElements = formSpec.Elements;
        }

        [Test]
        public void FormSpecs_AllElements_NumberCorrect()
        {
            var elementsExpected = 10;
            Assert.AreEqual(elementsExpected, _testFormElements.Count);
        }
        [Test]
        public void Elements_Includes_NamedElements([Values("DisplayOnly", "Close",
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
        public async Task kjkjkjkj()
        {
            _testFormProcessor.ExtractElements(out var displayOnlyButton, out var closeElement, out var display,
                out var input, out var select, out var submit,
                out var textArea, out var title,
                out var start, out var duration, _testFormElements);
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
            Assert.IsTrue(!submit.NotEnabled);
            await _testFormProcessor.HandleClickAsync(_testFormElements, "DisplayOnlyButton", _allSettings);
        }
        #region Utilities

        

        #endregion
    }
}