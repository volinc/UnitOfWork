﻿using Business.Data;

namespace Business.Entities
{
    public class Mapper
    {
        public Order From(OrderData data) => Order.Map.From(data);

        public OrderData To(Order entity) => Order.Map.To(entity);

        public OrderComment From(OrderCommentData data) => OrderComment.Map.From(data);

        public OrderCommentData To(OrderComment entity) => OrderComment.Map.To(entity);

        public Suggestion From(SuggestionData data) => Suggestion.From(data);

        public Shift From(ShiftData data) => Shift.From(data);

        public Vehicle From(VehicleData data) => Vehicle.From(data);

        public Driver From(DriverData data) => Driver.From(data);
    }
}
