using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Migrations
{
	public class Configuration : DropCreateDatabaseIfModelChanges<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			var location1 = new Location()
			{
				RetailerName = "Kate",
				Address = "Vinnitsya",
				LocationName = "Vn",
			};
			var location2 = new Location()
			{
				RetailerName = "Joy",
				Address = "New York",
				LocationName = "NY"
			};

			var projects = new List<Project>()
			{
				new Project()
				{
					ProjectName = "Test project 1",
					Questions = new List<Question>()
					{
						new Question()
						{
							Text = "What is your footer?",
							Location = location1,
						},
						new Question()
						{
							Text = "What is a problem with feature?",
							Location = location1,
						}
					}
				},
				new Project()
				{
					ProjectName = "Test project 2",
					Questions = new List<Question>()
					{
						new Question()
						{
							Text = "How many errors do you have?",
							Location = location1
						},
						new Question()
						{
							Text = "What problems do you have? :)",
							Location = location2
						}
					}
				}
			};

			foreach (Project project in projects)
			{
				context.Projects.Add(project);
			}
		}
	}
}
