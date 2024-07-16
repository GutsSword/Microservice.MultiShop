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
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var orderingWithId = await repository.GetByIdAsync(request.Id);
            await repository.DeleteAsync(orderingWithId);

        }

    }
}
