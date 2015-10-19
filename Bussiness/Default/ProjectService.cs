using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Repositories;

namespace Bussiness.Default
{
	internal sealed class ProjectService : IProjectService
	{
		private readonly IProjectRepository projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			this.projectRepository = projectRepository;
		}

		public IEnumerable<Project> GetProjects()
		{
			return projectRepository.GetAll();
		}

		public Project GetProjectById(int id)
		{
			var project = projectRepository.GetById(id);
			return project; 
		}

		public void UpdateProjectInfo(Project project)
		{
			projectRepository.UpdateProject(project);
		}
	}
}
