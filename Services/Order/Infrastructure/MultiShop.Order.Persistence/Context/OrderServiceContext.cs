using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost,1440 ; database = MultiShopOrderDb; User=sa; Password=123456aA*");
        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<Ordering> Ordering { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
