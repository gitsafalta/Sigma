using Microsoft.EntityFrameworkCore;
using Sigma.Core;

namespace Sigma.Infrastructure;

public class SigmaDBContext : DbContext
{
 public SigmaDBContext(DbContextOptions<SigmaDBContext> options) : base(options)
 {
 
 }
 public  DbSet<Candidates> Candidates { get; set; }
 
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
        // No fallback configuration
 }
    

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
   base.OnModelCreating(modelBuilder);
   
   modelBuilder.Entity<Candidates>(b=>{
            b.Property<DateTime>("CreatedOn")
            .HasColumnType("datetime");
        });    
 }
}