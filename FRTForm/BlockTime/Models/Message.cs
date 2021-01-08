// 05 01 2021 Created by Tony Horsham 13:17

using System;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(ModelConstants.MAX_NAME_LENGTH)]
        public string FromId { set; get; }
        [StringLength(ModelConstants.MAX_NAME_LENGTH)]
        public string ToId { set; get; }
        public DateTimeOffset TimeStamp { set; get; }
        public int? BlockId { set; get; }
        [StringLength(ModelConstants.MAX_MESSAGE_CONTENT_LENGTH)]
        public string Content { set; get; }

        public virtual Block Block { set; get; }
    }
}