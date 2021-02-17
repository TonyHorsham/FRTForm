using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FRTForm.BlockTime.Enums;

namespace FRTForm.BlockTime.Models
{
    /// <summary>
    /// Basic building block of booking system.
    /// </summary>
    public class Block
    {
        public int Id { set; get; } // set in database
        public string CalendarId { set; get; }
        public int LocationId { set; get; }
        public DateTimeOffset Start { set; get; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Duration { set; get; }
        public BlockType BlockType { set; get; }
        public DateTimeOffset End => Start.Add(Duration);

        // ********************** optional fields
        public Service Service { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string ClientId { set; get; }
        public List<Message> Messages { set; get; } = new List<Message>();
        public bool IsUnchanged => _originalStart == Start &&
                                   _originalDuration == Duration &&
                                   _originalBlockType == BlockType &&
                                   (Service == null || _originalService.Id == Service.Id) &&
                                   // Title may be changed by code between DisplayOnly and Edit modes
                                   //_originalTitle == Title &&
                                   _originalDescription == Description &&
                                   // Not intended to allow Message edit or deletion,
                                   //   so only need to check if a message has been added
                                   _originalMessages.Count == Messages.Count;

        //snapshot fields NOT persisted
        private DateTimeOffset _originalStart;
        private TimeSpan _originalDuration;
        private BlockType _originalBlockType;
        private Service _originalService;
        private string _originalTitle;
        private string _originalDescription;
        private List<Message> _originalMessages;
        private DateTimeOffset _snapshotTimeStamp;

        public Block(DateTimeOffset start, TimeSpan duration, int locationId,
            BlockType blockType, string calendarId, string title = "",
            string description = "", string clientId = "", List<Message> messages = null)
        {
            Start = start;
            Duration = duration;
            LocationId = locationId;
            BlockType = blockType;
            CalendarId = calendarId;
            ClientId = clientId;
            Messages = messages ?? Messages;
            Title = title;
            Description = description;
        }
        /// <summary>
        /// TakeSnapshot used to capture state so can restore after cancelled edit.
        /// Because the snapshot is not persisted, it will only have 'real' values
        ///   when CurrentBlockParameters is created in a GET request for a form.
        /// </summary>
        public void TakeSnapshot()
        {
            _originalStart = Start;
            _originalDuration = Duration;
            _originalBlockType = BlockType;
            _originalService = Service;
            _originalTitle = Title;
            _originalDescription = Description;
            _originalMessages = Messages;
            // timestamp so can time out opportunity to Restore
            _snapshotTimeStamp = DateTimeOffset.Now;
        }
        /// <summary>
        /// Restores state from snapshot
        /// </summary>
        public void Restore()
        {
            // TakeSnapshot and Restore, designed to work in unison
            //  to enable cancellation of an edit operation
            TimeSpan snapshotAge = DateTimeOffset.Now - _snapshotTimeStamp;
            // test age of snapshot to guard against inadvertent use
            // 30 minute limit maybe even be too long for practical valid use
            //TODO get value from application settings (NOT via SettingsService)
            TimeSpan ageLimit = new TimeSpan(0,30,0);
            if (snapshotAge > ageLimit)
            {
                throw new NotSupportedException("Block.Restore snapshotAge was " +
                        snapshotAge.ToString() + " - limit is " + ageLimit.ToString());
            }
            Start = _originalStart;
            Duration = _originalDuration;
            BlockType = _originalBlockType;
            Service = _originalService;
            Title = _originalTitle;
            Description = _originalDescription;
            Messages = _originalMessages;
        }
        // Message is immutable so no edit
        // also no delete
        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}