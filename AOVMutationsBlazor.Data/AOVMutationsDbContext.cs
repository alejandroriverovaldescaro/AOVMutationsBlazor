using AOVMutationsBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AOVMutationsBlazor.Data;

/// <summary>
/// Database context for AOV Mutations following SZV-PRIS schema
/// </summary>
public class AOVMutationsDbContext : DbContext
{
    public AOVMutationsDbContext(DbContextOptions<AOVMutationsDbContext> options)
        : base(options)
    {
    }

    public DbSet<MutationRequest> MutationRequests { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Employment> Employments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure MutationRequest
        modelBuilder.Entity<MutationRequest>(entity =>
        {
            entity.ToTable("MutationRequests");
            entity.HasIndex(e => e.RequestNumber).IsUnique();
            
            entity.HasOne(e => e.Person)
                .WithMany(p => p.MutationRequests)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Address)
                .WithMany(a => a.MutationRequests)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Employment)
                .WithMany(emp => emp.MutationRequests)
                .HasForeignKey(e => e.EmploymentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Person
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Persons");
            entity.HasIndex(e => e.BSN).IsUnique();
        });

        // Configure Address
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Addresses");
        });

        // Configure Employment
        modelBuilder.Entity<Employment>(entity =>
        {
            entity.ToTable("Employments");
            entity.Property(e => e.SalaryAmount).HasPrecision(18, 2);
            entity.Property(e => e.WorkHoursPerWeek).HasPrecision(5, 2);
        });
    }
}
