using Bussiness;
using DAL.Data;
using DAL.Repositories;
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

		[HttpGet]
		public ActionResult Setup()
		{
			IEnumerable<Project> projects = projectService.GetProjects();
			Project selectedProject = projects.First();

			var model = GetTempleteModel(selectedProject);
			model.Projects = projects;

			return View(model);
		}

		[HttpPost]
		public ActionResult Setup(TemplateModel model, int oldSelectedProjectId)
		{

			if (model.SelectedProjectId == oldSelectedProjectId)
			{
				return PartialView("SetupForm", model);
			}

			Project project = projectService.GetProjectById(model.SelectedProjectId);

			TemplateModel newModel = GetTempleteModel(project);

			return PartialView("SetupForm", newModel);
		}

		[HttpPost]
		public ActionResult Save(int id, string selectedFields, Separators separator)
		{
			TemplateModel model = new TemplateModel()
			{
				Separator = separator,
				SelectedFields = selectedFields
					.Split('-')
					.Select(x => Enum.Parse(typeof(AvaliableFields), x))
					.Cast<AvaliableFields>()
					.ToList(),
				SelectedProjectId = id
			};

			string template = ComposeTemplate(model);

			Project project = projectService.UpdateProjectTemplate(id, template);

			TemplateModel newModel = GetTempleteModel(project);

			return PartialView("SetupForm", newModel);
		}

		[HttpPost]
		public ActionResult RemoveField(int id, string selectedFields, Separators separator, int indexToRemove)
		{
			TemplateModel model = new TemplateModel()
			{
				Separator = separator,
				SelectedFields = selectedFields
					.Split('-')
					.Select(x => Enum.Parse(typeof(AvaliableFields), x))
					.Cast<AvaliableFields>()
					.ToList(),
				SelectedProjectId = id
			};

			model.SelectedFields.RemoveAt(indexToRemove);
			return PartialView("SetupForm", model);
		}

		[HttpPost]
		public ActionResult AddField(int id, string selectedFields, Separators separator)
		{
			var model = new TemplateModel()
			{
				Separator = separator,
				SelectedFields = selectedFields
					.Split('-')
					.Select(f => Enum.Parse(typeof(AvaliableFields), f))
					.Cast<AvaliableFields>()
					.ToList(),
				SelectedProjectId = id
			};

			model.SelectedFields.Add(model.Fields.First(f => f.IsUsed == false).Field);

			return PartialView("SetupForm", model);
		}

		private TemplateModel GetTempleteModel(Project project)
		{
			Separators separator;
			AvaliableFields[] selectedFields = projectService.GetTempleteItems(project.Template, out separator);

			var model = new TemplateModel(project.ProjectId, selectedFields, separator);

			return model;
		}

		private string ComposeTemplate(TemplateModel model)
		{
			string[] result = new[] {
				model.Separator.ToString()
			}
			.Union(model.SelectedFields.Select(x => x.ToString()))
			.ToArray();

			return string.Join(";", result);
		}
	}
}
