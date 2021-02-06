using System;
using System.ComponentModel.DataAnnotations;

namespace FRTForm.BlockTime.Models
{
    public class Service 
    {
        public int Id { set; get; }
        public string  CalendarId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public TimeSpan Duration { set; get; }
        public Decimal Price { set; get; }
        public Service(string calendarId, string name, 
            string description, TimeSpan duration, decimal price)
        {
            CalendarId = calendarId;
            Name = name;
            Description = description;
            Duration = duration;
            Price = price;
        }
    }
}
