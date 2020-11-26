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
        private IAllSettings _allSettings;
        private IFormProcessor _testFormProcessor;
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
            var formSpec = formSpecs["demoForm"];
            _testFormProcessor = formSpec.FormProcessor;
            _testFormElements = formSpec.Elements;
        }

        [Test]
        public void FormSpecs_AllElements_NumberCorrect()
        {
            // 6 elements needed
            Assert.AreEqual(6, _testFormElements.Count);
        }
        [Test]
        public void Elements_Includes_NamedElements([Values(
            "SubmitHeader", "Title", "Name", "Tel", "Code")] string name)
        {
            var element = _testFormElements.FirstOrDefault(fe => fe.Name == name);
            Assert.IsNotNull(element);
            //check that tests do not interfere
            ExtractElements(out var submit, out var title, out var nameInput, out var phoneInput,
                out var sendCode, out var code, _testFormElements);
            Assert.IsNull(nameInput.Value);
        }
        public async Task VaryingElements_VisibleEnabled_DependsOnRequiredFields()
        {
            // Code input element only visible (and enabled) if code generated
            // Name and Tel disabled once code generated

            // SubmitHeader only enabled if all required fields have valid values

            ExtractElements(out var submit, out var title, out var nameInput, out var phoneInput,
                out var sendCode, out var code, _testFormElements);
            nameInput.Value = "test";
            await _testFormProcessor.UpdateElementsAsync(_testFormElements, _allSettings, false);
        }

        #region Utilities

        private void ExtractElements(out SubmitAndCloseElement submit, out TitleElement title,
            out InputElement nameInput, out InputElement phoneInput,
            out ButtonElement sendCode, out InputElement code, List<IFormElement> elements)
        {
            submit = (SubmitAndCloseElement)elements
                .FirstOrDefault(fe => fe.Name == "SubmitHeader");
            title = (TitleElement)elements
                .FirstOrDefault(fe => fe.Name == "Title");
            nameInput = (InputElement)elements
                .FirstOrDefault(fe => fe.Name == "Name");
            phoneInput = (InputElement)elements
                .FirstOrDefault(fe => fe.Name == "Tel");
            sendCode = (ButtonElement)elements
                .FirstOrDefault(fe => fe.Name == "SendCode"); ;
            code = (InputElement)elements
                .FirstOrDefault(fe => fe.Name == "Code");
        }

        #endregion
    }
}