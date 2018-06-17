using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace WebApplication1.DbModels
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HDR4IFR;Database=Employee;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");
            });
        }
    }
}
