using System;
using System.ComponentModel.DataAnnotations;

namespace FRTForm.BlockTime.Models
{
    public class Service : IAuditedModel, IActivatableModel
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
        
        // N.B. no annotations - use Fluent API in caller's DataContext.OnModelCreating
        public int Id { set; get; }
        public string  CalendarId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public TimeSpan Duration { set; get; }
        public Decimal Price { set; get; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
