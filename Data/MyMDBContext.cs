using TIM.Lib.Model;
using Microsoft.EntityFrameworkCore;

namespace TIM.Lib.Data
{
    public class MyMDBContext : DbContext
    {
        public MyMDBContext(DbContextOptions<MyMDBContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<BookTransaction> BookTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<BookTransaction>().ToTable("BookTransaction");
        }
    }
}
