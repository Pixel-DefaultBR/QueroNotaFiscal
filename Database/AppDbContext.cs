using Microsoft.EntityFrameworkCore;
using QueroNotaFiscal.Models;

namespace QueroNotaFiscal.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<FiscalNoteEntity> FiscalNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiscalNoteEntity>(entity =>
            {
                entity.HasKey(e => e.FiscalNoteId);
                entity.Property(e => e.FiscalNoteNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => new { e.CNPJIssuing, e.FiscalNoteNumber }).IsUnique();
                entity.Property(e => e.TotalValue).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.IssueDate).IsRequired();
                entity.Property(e => e.CNPJIssuing).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CNPJRecipent).IsRequired().HasMaxLength(20);
            });
        }
    }
}
