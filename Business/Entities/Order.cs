using System;
using System.Collections.Generic;
using System.Linq;
using Business.Data;
using Business.DataAccess;

namespace Business.Entities
{
    public class Order : IEntity
    {
        object IEntity.Data => data;

        private readonly OrderData data;
        private readonly List<OrderComment> comments;

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
            var orderComment = OrderComment.Create(this, message, createdAt);
            var entity = (IEntity) orderComment;

            data.Comments.Add((OrderCommentData) entity.Data);
            comments.Add(orderComment);
        }        

        internal static string ThrowIfNullAddress(string address) =>
            address ?? throw new ArgumentNullException(nameof(address));

        internal static Order From(OrderData data) => data == null ? null : new Order(data);

        public static Order Create(string beginAddress, string endAddress, string commentMessage, DateTimeOffset createdAt)
        {            
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
