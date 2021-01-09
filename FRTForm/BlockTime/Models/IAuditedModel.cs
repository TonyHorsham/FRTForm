// 09 01 2021 Created by Tony Horsham 18:10

using System;

namespace FRTForm.BlockTime.Models
{
    public interface IAuditedModel
    {
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}