using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Data;

namespace DAL.Repositories.Default
{
	public class ProjectRepository : IProjectRepository
	{
		public IEnumerable<Project> GetAll()
		{
			using (DataContext context = new DataContext())
			{
				return context.Projects
					.Include(p => p.Questions.Select(q => q.Location))
					.ToArray();
			}
		}

		public Project GetById(int id)
		{
			using (DataContext context = new DataContext())
			{
				var project = context.Projects
					.Include(p => p.Questions)
					.Single(p => p.ProjectId == id);
				return project;
			}
		}

		public Project Update(Project project)
		{
			using (DataContext context = new DataContext())
			{
				var updatedProject = context.Projects.Attach(project);
				context.Entry(project).State = EntityState.Modified;
				context.SaveChanges();
				return updatedProject;
			}
		}
    }
}
