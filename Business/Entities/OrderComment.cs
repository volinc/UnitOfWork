using System;
using Business.Data;
using Business.DataAccess;

namespace Business.Entities
{
    public class OrderComment : IEntity
    {
        object IEntity.Data => data;

        private readonly OrderCommentData data;

        protected OrderComment(OrderCommentData data)
        {
            this.data = data;
        }

        public long Id => data.Id;

        public string Content => data.Content;

        public DateTimeOffset CreatedAt => data.CreatedAt;

        internal static string ThrowIfNullMessage(string message) =>
            message ?? throw new ArgumentNullException(nameof(message));

        internal static OrderComment From(OrderCommentData data) => data == null ? null : new OrderComment(data);

        internal static OrderComment Create(Order order, string content, DateTimeOffset createdAt)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new OrderComment(new OrderCommentData
            {
                OrderId = order.Id,
                Content = NormalizeText(content),
                CreatedAt = createdAt,                
            });
        }

        private static string NormalizeText(string content) => content.Trim();
    }
}
