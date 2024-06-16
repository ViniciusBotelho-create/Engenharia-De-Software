using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; } 

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LikesPost> likesPosts { get; set; }

        public DbSet<LikesComment> likesComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
            "Server=florasentinel.postgres.database.azure.com;" +
            "Port=5432;Database=FloraSentinel;" +
            "User Id=FloraSentinelDB;" +
            "Password=ProjetoEmGrupo123");
    }
}
