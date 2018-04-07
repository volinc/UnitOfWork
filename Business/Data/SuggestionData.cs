using System;

namespace Business.Data
{
    public class SuggestionData
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long ShiftId { get; set; }

        public decimal EstimatedPrice { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public OrderData Order { get; set; }

        public ShiftData Shift { get; set; }
    }
}
