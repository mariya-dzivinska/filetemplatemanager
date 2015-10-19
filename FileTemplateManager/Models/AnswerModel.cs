using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileTemplateManager.Models
{
	public class AnswerModel
	{
		public List<Project> Projects { get; set; }
		public List<Question> Questions { get; set; }
		public HttpPostedFileBase ImageFile { get; set; }

		public AnswerModel()
		{
		}
	}
}