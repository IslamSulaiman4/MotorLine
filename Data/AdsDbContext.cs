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
	}
}
