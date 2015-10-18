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
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult SetAnswer()
		{
			var model = new AnswerModel();
			return View(model);
		}
	}
}
