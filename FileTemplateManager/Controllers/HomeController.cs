using Bussiness;
using FileTemplateManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileTemplateManager.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProjectService projectService;

		public HomeController(IProjectService projectService)
		{
			this.projectService = projectService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult SetAnswer()
		{
			var model = new AnswerModel();
			model.Projects = projectService.GetProjects().ToList();
			model.Questions = projectService.GetProjectById(model.Projects.First().ProjectId).Questions;
			return View(model);
		}

		public ActionResult GetQuestions(int project)
		{
			var questions = projectService.GetProjectById(project).Questions;
			return Json(questions, JsonRequestBehavior.AllowGet);
		}
	}
}
