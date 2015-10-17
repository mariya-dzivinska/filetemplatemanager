using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileTemplateManager.Controllers
{
	public class ManageController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public string Save()
		{
			return "Hello world!";
		}
	}
}
