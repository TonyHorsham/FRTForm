// 27 11 2020 Created by Tony Horsham 11:06

using FRTForm.Settings;

namespace FRTForm.BlockTime.Settings
{
    // ReSharper disable once InconsistentNaming
    public interface IAllSettingsBT : IAllSettings
    {
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
        //**********************
    }
}