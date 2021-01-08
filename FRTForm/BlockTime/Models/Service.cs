using System;
using System.ComponentModel.DataAnnotations;

namespace FRTForm.BlockTime.Models
{
    public class Service
    {
        public Service()
        {
            // for EF
        }
        public Service(string calendarId, string name, 
            string description, TimeSpan duration, decimal price)
        {
            CalendarId = calendarId;
            Name = name;
            Description = description;
            Duration = duration;
            Price = price;
        }
        
        [StringLength(ModelConstants.MAX_NAME_LENGTH)]
        public string  CalendarId { set; get; }
        public int Id { set; get; }
        [StringLength(ModelConstants.MAX_NAME_LENGTH)]
        public string Name { set; get; }
        [StringLength(ModelConstants.MAX_DESCRIPTION_LENGTH)]
        public string Description { set; get; }
        public TimeSpan Duration { set; get; }
        public Decimal Price { set; get; }
    }
}
