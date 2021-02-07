using Microsoft.EntityFrameworkCore;
using Inalambria.Domain.Contracts;
using Inalambria.Domain.Entities;
using System;
using System.Threading.Tasks;
using Inalambria.Infrastructure.Filters;

namespace Inalambria.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepositoryWithId<Customer, CustomerFilter>
    {
    }

    public class CustomerRepository : RepositoryWithId<Customer, CustomerFilter>, ICustomerRepository
    {
        public CustomerRepository(InalambriaDbContext context) : base(context)
        {
            _dbset = context.Customers;
        }

        readonly DbSet<Customer> _dbset;
        public override DbSet<Customer> Dbset => _dbset;

        public override Task<Customer> GetAsync(int id)
        {
            return Dbset.Include("Pacientes").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
