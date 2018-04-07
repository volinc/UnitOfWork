using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DataAccess;
using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    internal class SuggestionRepository : ISuggestionRepository
    {
        private readonly DispatcherDbContext dbContext;        
        private readonly Mapper mapper;

        public SuggestionRepository(DispatcherDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;            
            this.mapper = mapper;
        }        

        public async Task<Suggestion> ReadByIdAsync(long suggestionId)
        {
            var data = await dbContext.Suggestions.SingleOrDefaultAsync(x => x.Id == suggestionId);

            return mapper.From(data);
        }

        public async Task<IReadOnlyList<Suggestion>> ReadAllByOrderIdAsync(long orderId)
        {
            var dataset = await dbContext.Suggestions.Where(x => x.OrderId == orderId).ToArrayAsync();

            return dataset.Select(mapper.From).ToList();
        }
    }
}