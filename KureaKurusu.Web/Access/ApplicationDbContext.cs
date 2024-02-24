using System.Text.Json;
using KureaKurusu.Data;
using KureaKurusu.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KureaKurusu.Web.Access;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Person> Persons { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Person>().ToTable("person")
            .Property(e => e.Aliases)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!)
            );
        
        modelBuilder
            .Entity<Person>().ToTable("person")
            .Property(e => e.Links)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<Link>>(v, (JsonSerializerOptions)null!)
            );

        // 其他配置...

        base.OnModelCreating(modelBuilder);
    }
}