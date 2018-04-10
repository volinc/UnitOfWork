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

        public Order(string beginAddress, string endAddress, string commentMessage, DateTimeOffset createdAt)
        {
            data = new OrderData
            {
                BeginAddress = beginAddress,
                EndAddress = endAddress,
                CreatedAt = createdAt,
            };

            comments = new List<OrderComment>();
            AddComment(commentMessage, createdAt);
        }

        protected Order(OrderData data)
        {
            this.data = data;

            comments = data.Comments.Select(OrderComment.From).ToList();
        }

        public long Id => data.Id;

        public string BeginAddress => data.BeginAddress;

        public string EndAddress => data.EndAddress;
        
        public IReadOnlyList<OrderComment> Comments => comments;

        public DateTimeOffset CreatedAt => data.CreatedAt;

        public void AddComment(string message, DateTimeOffset createdAt)
        {
            var comment = new OrderComment(Id, message, createdAt);

            data.Comments.Add(OrderComment.To(comment));
            comments.Add(comment);
        }        

        internal static string ThrowIfNullAddress(string address) =>
            address ?? throw new ArgumentNullException(nameof(address));

        internal static Order From(OrderData data) => data == null ? null : new Order(data);

        internal static OrderData To(Order entity) => entity?.data;     
    }
}
