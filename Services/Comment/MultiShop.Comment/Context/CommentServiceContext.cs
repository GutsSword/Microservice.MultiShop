using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442 ; database=MultiShopCommentDb ; User=sa ; Password=123456aA*"); 

        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
