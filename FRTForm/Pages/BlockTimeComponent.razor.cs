using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlexResForm.BlockTime.Models;
using FlexResForm.BlockTime.Settings;
using FlexResForm.BlockTime.Utilities;
using FlexResForm.Models;
using FlexResForm.Settings;
using FlexResForm.Utilities;
using Microsoft.AspNetCore.Components;

namespace FlexResForm.Pages
{
    public partial class BlockTimeComponent
    {
        [Parameter] public IAllSettings AllSettings { get; set; }
        [Parameter] public List<IFormElement> Elements { get; set; }
        [Parameter] public IFormProcessor FormProcessor { get; set; }
        [Parameter] public bool IsStart { get; set; }// if not Start, dealing with Duration
        [Parameter] public bool DisplayOnly { get; set; }
        [Parameter] public EventCallback<Block> BlockChanged { get; set; }

        private CurrentBlockParameters _currentBlockParameters;
        private CalendarSettings _calendarSettings;
        private Block _block;
        private DateTimeOffset _startLimit;
        private DateTimeOffset _endLimit;
        private bool _isAdmin;
        private bool _is24;
        private TimeSpan _timeSpan;
        private string _valueString;
        private bool _enablePlus5;
        private bool _enableMinus5;
        private bool _enablePlus30;
        private bool _enableMinus30;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _is24 = AllSettings.Is24;
            _currentBlockParameters = AllSettings.CurrentBlockParameters;
            _calendarSettings = AllSettings.CalendarSettings;
            _block = _currentBlockParameters.Block;
            _startLimit = _currentBlockParameters.StartLimit;
            _endLimit = _currentBlockParameters.EndLimit;
            _isAdmin = _currentBlockParameters.IsAdmin;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            _timeSpan = IsStart ? new TimeSpan(0, _block.Start.Hour, _block.Start.Minute, 0)
                : _block.Duration;
            SetAllowSettings();
            SetValueString();
        }

        private void SetAllowSettings()
        {
            // the number of arguments for GetEnableSettings is a bit clumsy
            //   but this critical piece of logic can be tested easily
            var enableValues = BlockTimeUtilities.GetEnableSettings(_block, IsStart,
                _startLimit, _endLimit, _calendarSettings.MinBlockDuration);
            _enablePlus30 = enableValues.Plus30;
            _enablePlus5 = enableValues.Plus5;
            _enableMinus5 = enableValues.Minus5;
            _enableMinus30 = enableValues.Minus30;
        }

        private async Task ChangeTime(int interval)
        {
            _timeSpan += TimeSpan.FromMinutes(interval);
            if (IsStart)
            {
                _block.Start = _block.Start.Date.Add(_timeSpan);
            }
            else
            {
                _block.Duration = _timeSpan;
            }
            SetAllowSettings();
            SetValueString();
            // Elements is updated
            await FormProcessor.UpdateElementsAsync(Elements, AllSettings, DisplayOnly);
            await BlockChanged.InvokeAsync(_block);
        }
        private void SetValueString()
        {
            string formatString = "";
            if (IsStart)
            {
                formatString = "dd MMM yyyy ";
                if (_is24)
                {
                    formatString += "HH:mm";
                }
                else formatString += "hh:mm tt";
                _valueString = _block.Start.ToString(formatString);
            }
            else
            {
                DateTime dummyDateTime = DateTime.Today.Add(_timeSpan);
                formatString = "HH:mm";
                _valueString = dummyDateTime.ToString(formatString);
            }
        }
    }
}
