// 21 11 2020 Created by Tony Horsham 16:06
// Copyright T & D H Family Trust

using System;
using FRTForm.BlockTime.Models;

namespace Demo.Settings
{/// <summary>
    /// If user changes settings in a session,
    ///  the changes need to be stored.
    /// So store and use a new value
    /// </summary>
    public readonly struct UserSettings
    {
        public UserSettings(IUser user, DayOfWeek weekStartDay, bool is24)
        {
            User = user;
            WeekStartDay = weekStartDay;
            Is24 = is24;
        }

        public IUser User { get; }
        public DayOfWeek WeekStartDay { get; }// only Monday and Sunday supported
        public bool Is24 { get; }
    }
}