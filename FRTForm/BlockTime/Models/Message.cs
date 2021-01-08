// 05 01 2021 Created by Tony Horsham 13:17

using System;

namespace FRTForm.BlockTime.Models
{
    public class Message
    {
        public Message()
        {
            // for EF
        }
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
        public string FromId { set; get; }
        public string ToId { set; get; }
        public DateTimeOffset TimeStamp { set; get; }
        public int? BlockId { set; get; }
        public string Content { set; get; }

        public virtual Block Block { set; get; }
    }
}