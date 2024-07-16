using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailByIdQueryResult
    {
        public int OrderDetailId { get; set; }
        // Product MongoDb' de tutuluyor.
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderingId { get; set; }
      //  public Ordering Ordering { get; set; }
    }
}
