using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWeb.Controllers
{
	[Authorize(Roles="Student")]
    public class StudentController : Controller
    {
		DataContext db = new DataContext();

        public ActionResult Index()
        {
			List<Assessment> assessments = db.assessments.Where(s => s.Student.userName == User.Identity.Name).ToList ();
			return View (assessments);
        }

		public ActionResult Details(int id)
		{
			// if bad request
			if (db.assessments.Where (a => a.id == id).Count () == 0 || db.assessments.Where (a => a.id == id).Single ().Student.userName != User.Identity.Name)
			{
				return RedirectToAction ("Index", "Home");
			}
			List<AssessmentDetail> assessmentDetails = db.assessmentDetails.Where(s => s.Assessment.id == id).ToList ();
			return View (assessmentDetails);
		}

		public ActionResult Feedback(int id)
		{
			if (db.assessments.Where (a => a.id == id).Count () == 0 || db.assessments.Where (a => a.id == id).Single ().Student.userName != User.Identity.Name)
			{
				return RedirectToAction ("Index", "Home");
			}
			FeedbackVM feedback = new FeedbackVM();
			feedback.feedback = db.feedback.Where(s => s.Assessment.Student.userName == User.Identity.Name && s.Assessment.id == id).ToList ();
			feedback.assessment = db.assessments.Where (a => a.id == id).Single ();
			return View (feedback);
		}

		[HttpPost]
		public ActionResult AddFeedback(FeedbackVM response)
		{
			int id = Int32.Parse (Request.Form ["assessment.id"]);
			if (db.assessments.Where (a => a.id == id).Count () == 0 || db.assessments.Where (a => a.id == id).Single ().Student.userName != User.Identity.Name)
			{
				return RedirectToAction ("Index", "Home");
			}

			// add the response
			Feedback fb = new CPWeb.Feedback ();
			fb.Assessment = db.assessments.Where (a => a.id == id).Single ();
			fb.date = DateTime.Now;
			fb.feedback = Request.Form["response.feedback"];
			fb.user = User.Identity.Name;

			db.feedback.Add (fb);

			db.SaveChanges ();

			return RedirectToAction ("Feedback", new { id = id });
		}
    }
}
