using FileTemplateManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileTemplateManager.Controllers
{
	public class ManageTemplateController : Controller
	{
		public ActionResult Setup()
		{
			var model = new TemplateModel();
			return View(model);
		}

		//[HttpPost]
		//public ActionResult Setup(TemplateModel result)
		//{
		//	var model = new TemplateModel();
		//	return View(model);
		//}

		[HttpPost]
		public ActionResult Setup(AvaliableFields[] selectedValues, Separators separator)
		{
			var model = new TemplateModel(selectedValues, separator);
			return View(model);
		}

		private void UpdateSampleFileName(List<FieldInfo> fields)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public string Save()
		{
			return "Hello world!";
		}
	}
}
