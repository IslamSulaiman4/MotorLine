using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorLine.Data;

namespace MotorLine
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var sqlServerConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
				?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			// Configure Access DB for ads
			builder.Services.AddDbContext<AdsDbContext>(options =>
				options.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ASUS\\OneDrive\\Documents\\MotorLine project\\MotorLineDB.accdb;"));

			// Configure SQL Server for Identity
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(sqlServerConnectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
