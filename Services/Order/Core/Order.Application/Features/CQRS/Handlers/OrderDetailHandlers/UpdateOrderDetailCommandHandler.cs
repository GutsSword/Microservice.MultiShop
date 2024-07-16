using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await repository.GetByIdAsync(command.OrderDetailId);

            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductId = command.ProductId;
            values.ProductAmount = command.ProductAmount;
            values.OrderDetailId = command.OrderDetailId;
            values.OrderingId = command.OrderingId;
            values.TotalPrice = command.TotalPrice;

            await repository.UpdateAsync(values);
        }
    }
}
