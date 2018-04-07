using System;
using System.Collections.Generic;

namespace Business.Data
{
    public class OrderData
    {
        public long Id { get; set; }

        public long? SuggestionId { get; set; }

        public string BeginAddress { get; set; }

        public string EndAddress { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public List<OrderCommentData> Comments { get; } = new List<OrderCommentData>();
    }
}
