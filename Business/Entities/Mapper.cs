using Business.Data;

namespace Business.Entities
{
    public class Mapper
    {
        public Order From(OrderData data) => Order.From(data);

        public OrderComment From(OrderCommentData data) => OrderComment.From(data);

        public Suggestion From(SuggestionData data) => Suggestion.From(data);

        public Shift From(ShiftData data) => Shift.From(data);

        public Vehicle From(VehicleData data) => Vehicle.From(data);

        public Driver From(DriverData data) => Driver.From(data);
    }
}
