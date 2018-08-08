using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiCRUD.DbModels
{
	public partial class EmployeeContext : DbContext
	{
		public virtual DbSet<Person> Person { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Server=DESKTOP-HDR4IFR;Database=Employee;Trusted_Connection=True;");
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
