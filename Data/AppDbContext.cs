using Microsoft.EntityFrameworkCore;
using ClubLedger.Models;

namespace ClubLedger.Data;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Account { get; set; }

    public DbSet<AccountType> AccountType { get; set; }

    public DbSet<Contact> Contact { get; set; }

    public DbSet<ContactType> ContactType { get; set; }

    public DbSet<JournalEntry> JournalEntry { get; set; }

    public DbSet<LedgerLine> LedgerLine { get; set; }
}

