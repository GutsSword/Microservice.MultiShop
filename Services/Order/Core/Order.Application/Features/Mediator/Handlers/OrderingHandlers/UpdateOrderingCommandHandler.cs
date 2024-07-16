using MediatR;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var orderingWithId = await repository.GetByIdAsync(request.OrderingId);
            
            orderingWithId.OrderingId = request.OrderingId;
            orderingWithId.UserId = request.UserId;
            orderingWithId.TotalPrice = request.TotalPrice;
            orderingWithId.OrderDate = request.OrderDate;

            await repository.UpdateAsync(orderingWithId);
    }
    }
}
