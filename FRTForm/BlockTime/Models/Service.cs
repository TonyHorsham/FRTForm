using System;

namespace FRTForm.BlockTime.Models
{
    public readonly struct Service
    {
        public Service(string calendarId, int id, string name, 
            string description, TimeSpan duration, decimal price)
        {
            CalendarId = calendarId;
            Id = id;
            Name = name;
            Description = description;
            Duration = duration;
            Price = price;
        }

        public string  CalendarId { get; }
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public TimeSpan Duration { get; }
        public Decimal Price { get; }
    }
}
