using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileTemplateManager.Models
{
	public class AnswerModel
	{
		public List<string> Projects { get; set; }
		public List<string> Questions { get; set; }
		public HttpPostedFileBase ImageFile { get; set; }

		public AnswerModel()
		{
			Projects = new List<string>{ "1", "2", "3"};
			Questions = new List<string> { "s", "asdf", "erjks" };
		}
	}
}