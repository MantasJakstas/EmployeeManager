using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        private static readonly string ConnectionString = Environment.GetEnvironmentVariable("connectionString")
            ?? throw new InvalidOperationException("You must set the UvsTaskConnectionString environment variable");

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employeeid);

                entity.ToTable("employees");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(128)
                    .HasColumnName("employeename");

                entity.Property(e => e.Employeesalary).HasColumnName("employeesalary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
