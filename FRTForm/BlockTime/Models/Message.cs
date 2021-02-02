// 05 01 2021 Created by Tony Horsham 13:17

using System;
using System.ComponentModel.DataAnnotations;

namespace FRTForm.BlockTime.Models
{
    public class Message
    {
        public Message(string fromId, string toId, DateTimeOffset timeStamp,
            string content, int? blockId = null)
        {
            FromId = fromId;
            ToId = toId;
            TimeStamp = timeStamp;
            BlockId = blockId;
            Content = content;
        }

        public int Id { set; get; } // set in database
        public string FromId { get; }
        public string ToId { get; }
        public DateTimeOffset TimeStamp { get; }
        public int? BlockId { get; }
        public string Content { get; }
    }
}