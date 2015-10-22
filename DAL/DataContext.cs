using DAL.Data;
using System.Data.Entity;

namespace DAL
{
	public sealed class DataContext : DbContext
	{
		public DbSet<Project> Projects { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Location> Locations { get; set; }

		public DbSet<Answer> Answers { get; set; }

		public DbSet<FileIndicator> FileIndicators { get; set; }

		internal DataContext() : base("DataContext")
		{

		}
	}
}
