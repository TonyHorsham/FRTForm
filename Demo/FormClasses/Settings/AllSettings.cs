// 23 11 2020 Created by Tony Horsham 16:17

using FRTForm.BlockTime.Settings;
using FRTForm.Settings;

namespace Demo.FormClasses.Settings
{
    public class AllSettings : IAllSettings
    {
        public AllSettings(IApplicationSettings applicationSettings, 
            CalendarSettings calendarSettings)
        {
            ApplicationSettings = applicationSettings;
            CalendarSettings = calendarSettings;
        }

        public IApplicationSettings ApplicationSettings { get; }
        public CalendarSettings CalendarSettings { get; }
        public CurrentBlockParameters CurrentBlockParameters { get; set; }
        public bool Is24 { get; set; }
    }
}