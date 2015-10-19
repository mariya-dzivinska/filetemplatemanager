using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
	public sealed class Project
	{
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string Template { get; set; }
		public List<Question> Questions { get; set; }
	}
}
