// 23 11 2020 Created by Tony Horsham 16:17

using FRTForm.BlockTime.Parameters;
using FRTForm.BlockTime.Settings;
using FRTForm.Parameters;

namespace Demo.FormClasses.Parameters
{
    public class AllParams : IAllParamsBT
    {
        public AllParams(IAppParams applicationSettings, 
            CalendarSettings calendarSettings)
        {
            AppParams = applicationSettings;
            CalendarSettings = calendarSettings;
        }

        public IAppParams AppParams { get; }
        public CalendarSettings CalendarSettings { get; }
        public CurrentBlockParameters CurrentBlockParameters { get; set; }
        public bool Is24 { get; set; }
    }
}