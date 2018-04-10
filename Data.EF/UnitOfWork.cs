using System.Threading.Tasks;
using Business.DataAccess;
using Business.Entities;

namespace Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DispatcherDbContext dbContext;
        private readonly Mapper mapper;

        private IOrderRepository orders;
        private ISuggestionRepository suggestions;

        public UnitOfWork(DispatcherDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IOrderRepository Orders => 
            orders ?? (orders = new OrderRepository(dbContext, mapper));

        public ISuggestionRepository Suggestions =>
            suggestions ?? (suggestions = new SuggestionRepository(dbContext, mapper));
        
        public async Task SaveAsync() 
            => await dbContext.SaveChangesAsync();
    }
}
