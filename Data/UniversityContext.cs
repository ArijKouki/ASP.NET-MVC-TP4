using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Data
{
	public class UniversityContext : DbContext
	{
		private static UniversityContext? _instance;
		public DbSet<Student>? Student { get; set; }
		public static UniversityContext Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Instantiate_University_Context();
				}
				return _instance;
			}
		}

		public UniversityContext(DbContextOptions o) : base(o) { }

		public static UniversityContext Instantiate_University_Context()
		{
			Debug.WriteLine("Creating a new University Context");
			var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();


			var connection = optionsBuilder.UseSqlite(@"Data Source=C:\\Users\\MSI\\source\\repos\\WebApplication4\\TP4.db");
			return new UniversityContext(optionsBuilder.Options);
		}


	}
}
