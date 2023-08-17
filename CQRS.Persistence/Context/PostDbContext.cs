using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Context
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
