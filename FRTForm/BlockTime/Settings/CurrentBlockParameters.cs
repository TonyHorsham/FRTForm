// 21 08 2020 Created by Tony Horsham 14:32
// Copyright T & D H Family Trust

using System;
using FRTForm.BlockTime.Models;

namespace FRTForm.BlockTime.Settings
{
    /// <summary>
    /// Unique for each request
    /// </summary>
    public readonly struct CurrentBlockParameters
    {
        public CurrentBlockParameters(Block block, CalendarDay calendarDay,
            string userId, bool isAdmin, DateTimeOffset startLimit, DateTimeOffset endLimit)
        {
            Block = block;
            CalendarDay = calendarDay;
            UserId = userId;
            IsAdmin = isAdmin;
            StartLimit = startLimit;
            EndLimit = endLimit;
        }

        public Block Block { get; }
        public CalendarDay CalendarDay { get; }
        public string UserId { get; }
        public bool IsAdmin { get; }
        public DateTimeOffset StartLimit { get; }
        public DateTimeOffset EndLimit { get; }
    }
}