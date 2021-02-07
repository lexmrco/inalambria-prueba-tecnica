using Microsoft.EntityFrameworkCore;
using Inalambria.Domain.Contracts;
using Inalambria.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Inalambria.Infrastructure.Filters;
using System.Collections.Generic;

namespace Inalambria.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepositoryWithId<Order, OrderFilter>
    {
    }

    public class OrderRepository : RepositoryWithId<Order, OrderFilter>, IOrderRepository
    {
        public OrderRepository(InalambriaDbContext context) : base(context)
        {
            _dbset = context.Orders;
        }

        readonly DbSet<Order> _dbset;
        public override DbSet<Order> Dbset => _dbset;

        public override async Task<IEnumerable<Order>> GetAllAsync(OrderFilter filter)
        {
            var query = Dbset.Include("Customer");
            if (filter.Since.HasValue)
                query = query.Where(x => x.OrderDate >= filter.Since.Value);
            if (filter.Until.HasValue)
                query = query.Where(x => x.OrderDate <= filter.Until.Value);
            if(!string.IsNullOrEmpty(filter.CustomerName))
                query = query.Where(x => x.Customer.CompanyName.Contains(filter.CustomerName));
            if(filter.OrderId.HasValue)
                query = query.Where(x => x.Id == filter.OrderId.Value);
            

            return await query.ToListAsync();
        }

        public override Task<Order> GetAsync(int id)
        {
            return Dbset.Include("Customer").Include("OrderDetails").Include("OrderDetails.Product").FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
