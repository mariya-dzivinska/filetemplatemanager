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

		[HttpPost]
		public ActionResult Setup(TemplateModel model)
		{
			return PartialView("SetupForm", model);
		}

		[HttpPost]
		public ActionResult RemoveField(int id, string selectedFields, Separators separator)
		{
			TemplateModel model = new TemplateModel
			{
				Separator = separator,
				SelectedFields = selectedFields
					.Split('-')
					.Select(x => Enum.Parse(typeof(AvaliableFields), x))
					.Cast<AvaliableFields>()
					.ToList()
			};

			model.SelectedFields.RemoveAt(id);
			return PartialView("SetupForm", model);
		}

		[HttpPost]
		public ActionResult AddField(string selectedFields, Separators separator)
		{
			var model = new TemplateModel()
			{
				Separator = separator,
				SelectedFields = selectedFields
					.Split('-')
					.Select(f => Enum.Parse(typeof(AvaliableFields), f))
					.Cast<AvaliableFields>()
					.ToList()
			};

			model.SelectedFields.Add(model.Fields.First(f => f.IsUsed == false).Field);

			return PartialView("SetupForm", model);
		}
	}
}
