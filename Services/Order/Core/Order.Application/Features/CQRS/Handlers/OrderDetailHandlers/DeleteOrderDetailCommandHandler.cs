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
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(values);
        }
    }
}
