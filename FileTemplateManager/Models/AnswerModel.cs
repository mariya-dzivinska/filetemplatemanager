using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileTemplateManager.Models
{
	public class AnswerModel
	{
		public IEnumerable<Project> Projects { get; set; }

		public Project SelectedProject { get; set; }

		public IEnumerable<Question> Questions { get; set; }
		public HttpPostedFileBase ImageFile { get; set; }
		public Question SelectedQuestion { get; set; }
	}
}