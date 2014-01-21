using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebMatrix.WebData;
using System.Web.Security;

namespace CPWeb.Controllers
{
	public class HomeController : Controller
	{
		DataContext db = new DataContext();

		public ActionResult Index ()
		{
			if (!Request.IsAuthenticated) 
			{
				return RedirectToAction ("LogOn", "Account");
			} 
			else if (Roles.IsUserInRole (User.Identity.Name, "Student")) 
			{
				return RedirectToAction ("Index", "Student");
			} 
			else if (Roles.IsUserInRole (User.Identity.Name, "Admin")) 
			{
				return RedirectToAction ("Index", "Admin");
			}


			return View ();
		}
	}
}

