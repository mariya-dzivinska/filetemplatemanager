using Bussiness;
using DAL.Data;
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
		private readonly IProjectService projectService;

		public ManageTemplateController(IProjectService projectService)
		{
			this.projectService = projectService;
		}

		public ActionResult Setup()
		{
			IEnumerable<Project> projects = projectService.GetProjects().ToArray();
			var model = new TemplateModel();
			model.Projects = projects;
			return View(model);
		}

		[HttpPost]
		public ActionResult Setup(TemplateModel model, int oldSelectedProjectId)
		{
			var projectToUpdate = projectService.GetProjectById(model.SelectedProjectId);
			projectService.UpdateProjectInfo(projectToUpdate);

			if (model.SelectedProjectId == oldSelectedProjectId)
			{
				return PartialView("SetupForm", model);
			}
			else
			{
				var newModel = new TemplateModel();
				newModel.SelectedProjectId = model.SelectedProjectId;
				return PartialView("SetupForm", newModel);
			}
		}

		[HttpPost]
		public ActionResult RemoveField(int id, string selectedFields, Separators separator)
		{
			TemplateModel model = new TemplateModel()
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
