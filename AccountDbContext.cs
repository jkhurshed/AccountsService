using Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounts;

public class AccountDbContext(DbContextOptions<AccountDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>();
    }
}
