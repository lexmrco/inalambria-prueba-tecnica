using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Inalambria.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Inalambria.Domain.Contracts;
using Inalambria.Domain.Entities;
using Inalambria.Infrastructure.Filters;
using Inalambria.Infrastructure.Repositories;
using System.Threading.Tasks;
using Inalambria.WebApi.ViewModels.Sales;
using Inalambria.WebApi.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inalambria.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        protected readonly IRepositoryWithId<Order, OrderFilter> _repository;

        public SalesController(IOrderRepository repository)
        {
            _repository = repository;
        }

        private static readonly List<SalesViewModel> sales = new List<SalesViewModel>
        {
            new SalesViewModel(){ Id = 1, BillDate = DateTime.Parse("2020/11/20"), BillNumber = "1001", CustomerName = "City 1", CustomerPhone = "Phone 1", CustomerAddress = "Email 1" }
        };

        // GET: <SalesController>
        [HttpGet]
        public async Task<IEnumerable<SalesViewModel>> Get(int? orderid, string since, string until, string customerName)
        {
            DateTime? sinceDate = CustomDateTime.Parse(since, true);
            DateTime? untilDate = CustomDateTime.Parse(until, false);

            OrderFilter filter = new OrderFilter()
            {
                OrderId = orderid,
                Since = sinceDate,
                Until = untilDate,
                CustomerName = customerName
            };
            var list = (await _repository.GetAllAsync(filter)).Select(x=> new SalesViewModel() { 
                Id = x.Id,
                BillDate = x.OrderDate.Value,
                BillNumber = x.Id.ToString(),
                CustomerName = x.Customer.CompanyName,
                CustomerAddress = x.Customer.Address,
                CustomerPhone = x.Customer.Phone
            });

            return list;
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public async Task<SalesViewModel> Get(int id)
        {
            var entity = await _repository.GetAsync(id);
            var viewModel =  new SalesViewModel()
            {
                Id = entity.Id,
                BillDate = entity.OrderDate.Value,
                BillNumber = entity.Id.ToString(),
                CustomerName = entity.Customer.CompanyName,
                CustomerAddress = entity.Customer.Address,
                CustomerPhone = entity.Customer.Phone
            };
            foreach (var item in entity.OrderDetails)
            {
                OrderDetailsModel detail = new OrderDetailsModel() { 
                    ProductName = item.Product.ProductName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                };
                viewModel.OrderDetails.Add(detail);
            }
            return viewModel;
        }


        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
