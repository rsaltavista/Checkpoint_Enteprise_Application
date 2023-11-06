using CheckpointBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckpointBlog.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public Context(DbContextOptions op) : base(op)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(f => f.Comentarios)
                .WithOne(f => f.Post)
                .HasForeignKey(f => f.PostId);

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
