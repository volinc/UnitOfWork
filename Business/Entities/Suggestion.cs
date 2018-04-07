using System;
using Business.Data;

namespace Business.Entities
{
    public class Suggestion
    {
        private readonly SuggestionData data;

        protected Suggestion(SuggestionData data)
        {
            this.data = data;
        }

        public long Id => data.Id;

        public long OrderId => data.OrderId;

        public long ShiftId => data.ShiftId;

        public decimal EstimatedPrice => data.EstimatedPrice;

        public TimeSpan ArrivalTime => data.ArrivalTime;

        public DateTimeOffset CreatedAt => data.CreatedAt;

        internal static Suggestion From(SuggestionData data) => data == null ? null : new Suggestion(data);

        internal static Suggestion Create()
        {
            return new Suggestion(new SuggestionData
            {

            });
        }
    }
}
