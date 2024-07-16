using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var valueWithId = await repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult()
            {
               OrderDetailId = valueWithId.OrderDetailId,
               OrderingId = valueWithId.OrderingId,
               ProductAmount = valueWithId.ProductAmount,
               ProductId = valueWithId.ProductId,
               ProductName = valueWithId.ProductName,
               ProductPrice = valueWithId.ProductPrice,
               TotalPrice = valueWithId.TotalPrice
            };
        }
    }
}
