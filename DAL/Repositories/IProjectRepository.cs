using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public interface IProjectRepository
	{
		IEnumerable<Project> GetAll();

		Project GetById(int id);

		void Update(Project project);
	}
}
