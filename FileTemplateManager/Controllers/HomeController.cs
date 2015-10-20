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
			model.Projects = projectService.GetProjects();
			model.SelectedProject = model.Projects.FirstOrDefault();
			model.Questions = model.SelectedProject.Questions;
			model.SelectedQuestion = model.SelectedProject.Questions.FirstOrDefault();
			return View(model);
		}

		public ActionResult GetQuestions(int projectId)
		{
			var questions = projectService
				.GetProjectById(projectId)
				.Questions
				.Select(x => new
				{
					QuestionId = x.QuestionId,
					Text = x.Text
				});
			return Json(questions, JsonRequestBehavior.AllowGet);
		}
	}
}
