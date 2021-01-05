using System;

namespace FRTForm.BlockTime.Parameters
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
        //TODO consider a repository of these, so only one in the system rather than one for each user
        //Also consider including a List<Block> and raising events for any block changes (including addition and deletion)
        //Day.razor.cs instances to subscribe to the event, so that any changes result in all users getting the update

        //block addition on first come best dressed, so 'second' user with a block with overlapping time to get 'not possible' message
        //  this almost certainly means Day should raise an event so that BlockForm can subscribe.
        //  similar logic applies to changing block times - the limits may change before submit
    }
}