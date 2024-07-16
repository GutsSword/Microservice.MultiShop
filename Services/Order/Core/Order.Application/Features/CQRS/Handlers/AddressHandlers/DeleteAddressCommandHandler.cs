using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class DeleteAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteAddressCommand deleteAddressCommand)
        {
            var values = await repository.GetByIdAsync(deleteAddressCommand.Id);
            await repository.DeleteAsync(values);
        }
    }
}
