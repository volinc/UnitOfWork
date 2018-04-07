using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DataAccess;
using Business.Entities;

namespace Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DispatcherDbContext dbContext;
        private readonly Mapper mapper;

        private IOrderRepository orderRepository;
        private ISuggestionRepository suggestionRepository;

        public UnitOfWork(DispatcherDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IOrderRepository OrderRepository => orderRepository ?? 
            (orderRepository = new OrderRepository(dbContext, mapper));

        public ISuggestionRepository SuggestionRepository => suggestionRepository ??
            (suggestionRepository = new SuggestionRepository(dbContext, mapper));

        public void Add<T>(T entity) where T : IEntity 
            => dbContext.Add(entity.Data);

        public void AddRange<T>(IEnumerable<T> entities) where T : IEntity
            => dbContext.AddRange(entities.Select(x => x.Data));

        public async Task SaveAsync() 
            => await dbContext.SaveChangesAsync();
    }
}
