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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values =  await repository.GetByIdAsync(updateAddressCommand.AddressId);

            values.AddressId = updateAddressCommand.AddressId;
            values.UserId = updateAddressCommand.UserId;
            values.Detail = updateAddressCommand.Detail;
            values.District = updateAddressCommand.District;
            values.City = updateAddressCommand.City;

            await repository.UpdateAsync(values);
        }
    }
}
