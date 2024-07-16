using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await repository.CreateAsync(new OrderDetail
            {
                ProductId = command.ProductId,
                ProductAmount = command.ProductAmount,
                TotalPrice  = command.TotalPrice,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                OrderingId = command.OrderingId,
            });
        }
    }
}
