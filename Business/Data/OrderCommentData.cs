using System;

namespace Business.Data
{
    public class OrderCommentData
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }        
    }
}
