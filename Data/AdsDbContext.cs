using Microsoft.EntityFrameworkCore;
using MotorLine.Models;

namespace MotorLine.Data
{
	public class AdsDbContext : DbContext
	{
		public AdsDbContext(DbContextOptions<AdsDbContext> options)
		   : base(options)
		{
		}

		public DbSet<Ad> Ads { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ASUS\\OneDrive\\Documents\\MotorLine project\\MotorLineDB.accdb;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ad>().HasIndex(a => a.Title).IsUnique(); // Add unique constraint on Title
			modelBuilder.Entity<Ad>().Property(a => a.Price).HasColumnType("decimal(18,2)"); // Ensure correct column type for Price
		}
	}
}