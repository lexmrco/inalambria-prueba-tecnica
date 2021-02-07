using Microsoft.EntityFrameworkCore;
using Inalambria.Domain.Contracts;
using Inalambria.Domain.Entities;
using System;
using System.Threading.Tasks;
using Inalambria.Infrastructure.Filters;
using System.Collections.Generic;

namespace Inalambria.Infrastructure.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail, OrderDetailFilter>
    {
    }

    public class OrderDetailRepository : Repository<OrderDetail, OrderDetailFilter>, IOrderDetailRepository
    {
        public OrderDetailRepository(InalambriaDbContext context) : base(context)
        {
            _dbset = context.OrderDetails;
        }

        readonly DbSet<OrderDetail> _dbset;
        public override DbSet<OrderDetail> Dbset => _dbset;

        public override async Task<IEnumerable<OrderDetail>> GetAllAsync(OrderDetailFilter filter)
        {
            return await Dbset.Include("Product").ToListAsync();
        }
    }
}
