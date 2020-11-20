using System;

namespace FlexResForm.BlockTime.Models
{
    /// <summary>
    /// This is a unique reference for one Calendar for one Location for one DayDate.
    /// Each user will generate a new instance.
    /// </summary>
    public readonly struct CalendarDay
    {
        public readonly string CalendarId;
        public readonly int LocationId;
        public readonly DateTimeOffset DayDate;
        public CalendarDay(string calendarId, DateTimeOffset dayDate,
            int locationId)
        {
            CalendarId = calendarId;
            LocationId = locationId;
            DayDate = dayDate.Date;// cannot rely on caller just sending the date
        }
    }
}