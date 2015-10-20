using DAL.Data;
using DAL.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
	public interface IProjectService
	{
		IEnumerable<Project> GetProjects();

		Project GetProjectById(int id);

		Project UpdateProjectTemplate(int projectId, string template);

		string GetTemplatePattern(int questionId);

		AvaliableFields[] GetTempleteItems(string template, out Separators separator);
	}
}
