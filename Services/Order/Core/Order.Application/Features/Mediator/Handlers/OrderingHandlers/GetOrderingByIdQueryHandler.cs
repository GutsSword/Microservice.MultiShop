using MediatR;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var getWithId = await repository.GetByIdAsync(request.Id);
            
            return new GetOrderingByIdQueryResult
            {
                OrderDate = getWithId.OrderDate,
                OrderDetail = getWithId.OrderDetail,
                OrderingId = request.Id,
                TotalPrice = getWithId.TotalPrice,
                UserId = getWithId.UserId,
            };
        }
    }
}
