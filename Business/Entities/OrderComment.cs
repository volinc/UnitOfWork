using System;
using Business.Data;

namespace Business.Entities
{
    public class OrderComment
    {
        private readonly OrderCommentData data;

        public OrderComment(long orderId, string content, DateTimeOffset createdAt)
        {
            ThrowIfNullContent(content);

            data = new OrderCommentData
            {
                OrderId = orderId,
                Content = NormalizeText(content),
                CreatedAt = createdAt,
            };
        }

        protected OrderComment(OrderCommentData data)
        {
            this.data = data;
        }

        public long Id => data.Id;

        public string Content => data.Content;

        public DateTimeOffset CreatedAt => data.CreatedAt;

        internal static void ThrowIfNullContent(string content)
        {
            if (content == null) 
                throw new ArgumentNullException(nameof(content));
        }

        internal static class Map
        {
            internal static OrderComment From(OrderCommentData data) => data == null ? null : new OrderComment(data);

            internal static OrderCommentData To(OrderComment entity) => entity?.data;   
        }
        
        private static string NormalizeText(string content) => content.Trim();        
    }
}
