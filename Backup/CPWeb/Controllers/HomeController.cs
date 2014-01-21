using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace CPWeb.Controllers
{
	public class HomeController : Controller
	{
		DataContext db = new DataContext();

		public ActionResult Index ()
		{
			TestModel tm = new TestModel ();
			tm.name = "Sam";

			//db.tests.Add(tm);

			//db.SaveChanges ();

			ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View (tm);
		}
	}
}

