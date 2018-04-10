using System;
using System.Collections.Generic;
using System.Linq;
using Business.Data;

namespace Business.Entities
{
    public class Order
    {
        private readonly OrderData data;
        private readonly List<OrderComment> comments;

        protected Order(OrderData data)
        {
            this.data = data;

            comments = data.Comments.Select(OrderComment.Map.From).ToList();
        }

        public long Id => data.Id;

        public string BeginAddress => data.BeginAddress;

        public string EndAddress => data.EndAddress;
        
        public IReadOnlyList<OrderComment> Comments => comments;

        public DateTimeOffset CreatedAt => data.CreatedAt;

        public void AddComment(string message, DateTimeOffset createdAt)
        {
            var comment = OrderComment.Create(this, message, createdAt);

            data.Comments.Add(OrderComment.Map.To(comment));
            comments.Add(comment);
        }        

        internal static void ThrowIfNullAddress(string address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
        }

        internal class Map
        {
            public static Order From(OrderData data) => data == null ? null : new Order(data);

            public static OrderData To(Order entity) => entity?.data;   
        }

        public static Order CreatePresent(string beginAddress, string endAddress, string commentMessage, DateTimeOffset createdAt)
        {
            ThrowIfNullAddress(beginAddress);
            ThrowIfNullAddress(endAddress);

            var order = new Order(new OrderData
            {
                BeginAddress = beginAddress,
                EndAddress = endAddress,
                CreatedAt = createdAt,
            });
            
            order.AddComment(commentMessage, createdAt);
            return order;
        }
    }
}
