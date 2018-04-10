using System;
using Business.Data;

namespace Business.Entities
{
    public class OrderComment
    {
        private readonly OrderCommentData data;
        
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
            public static OrderComment From(OrderCommentData data) => data == null ? null : new OrderComment(data);

            public static OrderCommentData To(OrderComment entity) => entity?.data;   
        }
        
        private static string NormalizeText(string content) => content.Trim();

        public static OrderComment Create(Order order, string content, DateTimeOffset createdAt)
        {
            ThrowIfNullContent(content);

            return new OrderComment(new OrderCommentData
            {
                OrderId = order.Id,
                Content = NormalizeText(content),
                CreatedAt = createdAt,
            });
        }
    }
}
