using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var result = await repository.GetByIdAsync(getAddressByIdQuery.Id);
            return new GetAddressByIdQueryResult()
            {
                AddressId = result.AddressId,
                City = result.City,
                Detail=result.Detail,
                District = result.District,
                UserId = result.UserId
            };
        }
    }
}
