// 19 09 2020 Created by Tony Horsham 14:06
// Copyright T & D H Family Trust

using FlexResForm.BlockTime.Settings;

namespace FlexResForm.Settings
{
    /// <summary>
    ///  Generally just 'passed through' rather than any values used in the project
    ///  Other than IApplicationSettings.AppFormSpecs, the list of form specifications.
    /// 
    ///  22SEP20 Decision that any form element that needs extra properties (e.g. has a custom component), 
    ///  should be accommodated in the interface, to avoid the need to cast to access the properties.
    /// </summary>
    public interface IAllSettings
    {
        public IApplicationSettings ApplicationSettings { get; }

        // 22SEP20 Decision that any IFormElement that needs extra properties
        // should be accommodated in the interface, to avoid the need to cast to access the properties

        //***************************************
        // BlockTimeComponent required properties
        public CalendarSettings CalendarSettings { get; }
        // unique for each request
        public CurrentBlockParameters CurrentBlockParameters { get; set; }
        // from UserSettings in Calendar, no other fields required here
        // N.B. quite likely that AllSettingsCalendar will have the class, but that would mean a cast (and assumption)
        public bool Is24 { get; set; }
        // BlockTimeComponent required properties
        //***************************************
    }
}