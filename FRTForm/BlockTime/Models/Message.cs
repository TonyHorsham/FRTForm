// 05 01 2021 Created by Tony Horsham 13:17

using System;

namespace FRTForm.BlockTime.Models
{
    public readonly struct Message
    {
        public Message(int id, string fromId, string toId, DateTimeOffset timeStamp,
            string content, int? blockId = null)
        {
            Id = id;
            FromId = fromId;
            ToId = toId;
            TimeStamp = timeStamp;
            BlockId = blockId;
            Content = content;
        }

        public int Id { get; }
        public string FromId { get; }
        public string ToId { get; }
        public DateTimeOffset TimeStamp { get; }
        public int? BlockId { get; }
        public string Content { get; }


    }
}